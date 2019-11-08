using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dbnd.Logic.Interfaces;
using Dbnd.Logic.Objects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dbnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IRepository _repository;
        private IHttpClientFactory _clientFactory;
        private Authorizer _auth;

        #region Client
        public ClientController(IRepository repository, IHttpClientFactory clientFactory)
        {
            _repository = repository;
            _clientFactory = clientFactory;
            _auth = new Authorizer(_clientFactory);
        }

        // GET: api/client
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get()
        {
            try
            {
                UserProfile userProfile = await _auth.GetUserProfile(Request.Headers["Authorization"].ToString());

                try
                {
                    object rob = new { id = (await _repository.GetClientByEmailAsync(userProfile.email)).ClientID.ToString() };
                    return Ok(rob);
                }
                catch
                {
                    await _repository.CreateClientAsync(userProfile.name, userProfile.email);
                    object rob = new { id = (await _repository.GetClientByEmailAsync(userProfile.email)).ClientID.ToString() };
                    return Ok(rob);
                }
            }
            catch
            {
                throw new Exception("Failed to handle client login/fetch.");
            }
        }

        //GET: api/client/{id}
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), id.ToString())))
                return Forbid();

            Client client = await _repository.GetClientByIDAsync(id);
            return Ok(client);
        }

        // PUT: api/client/update/{id}
        [HttpPut("update/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put(Guid id, [FromBody, Bind("UserName, Email")] Client changedClient)
        {
            if (!await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), id.ToString()))
                return Forbid();

            await _repository.UpdateClientByIDAsync(id, changedClient);
            var returnClient = await _repository.GetClientByIDAsync(id);
            return AcceptedAtAction("Get", "Client", null, returnClient);
        }

        // DELETE: api/client/delete{id}
        [HttpDelete("delete/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), id.ToString()))
                return Forbid();

            await _repository.DeleteClientByIDAsync(id);
            return NoContent();
        }
        #endregion

        #region Characters
        // POST Create new character: api/clients/{clientId}/characters/new
        [HttpPost]
        public async Task<ActionResult> Post([FromBody, Bind("ClientID,FirstName,LastName")] Character character)
        {
            await _repository.CreateCharacterAsync(character.ClientID, character.FirstName, character.LastName);
            return Created("api/Character/", character);
        }

        //  GET Get all characters: api/clients/{clientId}/characters
        //  GET Get character info: api/clients/{clientId}/characters/{characterId}
        [HttpGet("{clientId}/characters/{characterId}")]
        public Task<Character> GetCharacter(Guid clientId, Guid characterId)
        {
            return _repository.GetCharacterByIDAsync(characterId);
        }

        //  PUT Update character info: api/clients/{clientId}/characters/update/{characterId}
        [HttpPut("{clientId}/characters/update/{characterId}")]
        public async Task<ActionResult> Put(Guid clientId, Guid characterId, [FromBody, Bind("FirstName, LastName")] Character changedCharacter)
        {
            await _repository.UpdateCharacterByIDAsync(characterId, changedCharacter);
            var returnCharacter = await _repository.GetCharacterByIDAsync(characterId);
            return AcceptedAtAction("Get", "Character", null, returnCharacter);
        }

        //  DELETE Delete character: api/clients/{clientId}/characters/delete/{characterId}
        [HttpDelete("{clientId}/characters/delete/{characterId}")]
        public async Task<ActionResult> DeleteCharacter(Guid clientId, Guid characterId)
        {
            await _repository.DeleteCharacterByIDAsync(characterId);
            return NoContent();
        }
        #endregion

        #region Games
        //  POST Create new game: api/clients/{clientId}/games/new
        [HttpPost]
        public async Task<ActionResult> Post([FromBody, Bind("ClientID, GameName")] Game game)
        {
            await _repository.CreateGameAsync(game.ClientID, game.GameName);
            return Created("api/Game/", game);
        }

        //  GET Get client's games: api/clients/{clientId}/games
        [HttpGet("{clientId}/games")]
        public async Task<List<Game>> GetGames(Guid id)
        {
            return await _repository.GetGamesByClientIDAsync(id);
        }

        //  GET Get game info: api/clients/{clientId}/games/{gameId}
        [HttpGet("{clientId}/games/{gameId}")]
        public async Task<Game> GetGame(Guid clientId, Guid gameId)
        {
            return await _repository.GetGameByIDAsync(gameId);
        }

        //  PUT Add character to game: api/clients/{clientId}/games/{gameId}/addCharacter/

        //  PUT Update game info: api/clients/{clientId}/games/update/{gameId}
        [HttpPut("{clientId}/games/update/{gameId}")]
        public async Task<ActionResult> Put(Guid id, [FromBody, Bind("GameName")] Game changedGame)
        {
            await _repository.UpdateGameAsync(id, changedGame);
            var returnGame = await _repository.GetGameByIDAsync(id);
            return AcceptedAtAction("Get", "Game", null, returnGame);
        }

        //  DELETE Delete game: api/clients/{clientId}/games/delete/{gameId}
        [HttpDelete("{clientId}/games/delete/{gameId}")]
        public async Task<ActionResult> DeleteGame(Guid clientId, Guid gameId)
        {
            await _repository.DeleteGameByIDAsync(gameId);
            return NoContent();
        }
        #endregion

        #region Overview
        //  POST Create overview: api/clients/{clientId}/games/{gameId}/overviews/new
        //  GET Get all overviews of a game: api/clients/{clientId}/games/{gameId}/overviews
        //  GET     Get overview info: api/clients/{clientId}/games/{gameId}/overviews/{overviewId}
        //  PUT Update overview: api/clients/{clientId}/games/{gameId}/overviews/update/{overviewId}
        //  DELETE Remove overview: api/clients/{clientId}/games/{gameId}/overviews/delete/{overviewId}
        #endregion
    }
}

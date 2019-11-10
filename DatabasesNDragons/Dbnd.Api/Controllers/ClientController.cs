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
        private IAuthorizer _auth;

        public ClientController(IRepository repository, IAuthorizer auth)
        {
            _repository = repository;
            _auth = auth;
        }

        #region Client
        // GET: api/client
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<object>> GetClientId()
        {
            try
            {
                UserProfile userProfile = await _auth.GetUserProfile(Request.Headers["Authorization"].ToString());
                Client client = await _repository.GetClientByEmailAsync(userProfile.email);

                if (client == null)
                {
                    await _repository.CreateClientAsync(userProfile.name, userProfile.email);
                    client = await _repository.GetClientByEmailAsync(userProfile.email);
                }

                object responseObject = new { id = client.ClientID.ToString() };
                return Ok(responseObject);
            }
            catch
            {
                throw new Exception("Failed to handle client login/fetch.");
            }
        }

        // GET: api/client/{id}
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Client>> GetClient(Guid id)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), id.ToString())))
                return Forbid();

            Client client = await _repository.GetClientByIDAsync(id);
            return Ok(client);
        }

        // PUT: api/client/{id}/update
        [HttpPut("{id}/update")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Client>> PutClient(Guid id, [FromBody, Bind("UserName, Email")] Client changedClient)
        {
            if (!await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), id.ToString()))
                return Forbid();

            await _repository.UpdateClientByIDAsync(id, changedClient);
            var returnClient = await _repository.GetClientByIDAsync(id);
            return AcceptedAtAction("Get", "Client", null, returnClient);
        }

        // DELETE: api/client/{id}/delete
        [HttpDelete("{id}/delete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Client>> DeleteClient(Guid id)
        {
            if (!await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), id.ToString()))
                return Forbid();

            await _repository.DeleteClientByIDAsync(id);
            return NoContent();
        }
        #endregion

        #region Characters
        // POST: Create new character: api/clients/{clientId}/characters/new
        [HttpPost("{clientId}/characters/new")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Character>> PostCharacter(Guid clientId, [FromBody, Bind("FirstName, LastName")] Character character)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId.ToString())))
                return Forbid();

            Character newCharacter = await _repository.CreateCharacterAsync(character.ClientID, character.FirstName, character.LastName);
            return Created($"api/client/{clientId}/characters/{newCharacter.CharacterID}", newCharacter);
        }

        // GET: Get all characters: api/clients/{clientId}/characters
        [HttpGet("{clientId}/characters")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Character>> GetAllCharacters(Guid clientId)
        {
            try
            {
                if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId.ToString())))
                    return Forbid();

                return Ok(await _repository.GetClientCharactersAsync(clientId));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // GET: Get character info: api/clients/{clientId}/characters/{characterId}
        [HttpGet("{clientId}/characters/{characterId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Character>> GetCharacter(Guid clientId, Guid characterId)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId .ToString())))
                return Forbid();

            Character character = await _repository.GetCharacterByIDAsync(characterId);
            if (character == null)
                return NotFound();
            if (character.ClientID != clientId)
                return Forbid();

            return Ok(character);
        }

        // PUT: Update character info: api/clients/{clientId}/characters/{characterId}/update
        [HttpPut("{clientId}/characters/{characterId}/update")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Character>> PutCharacter(Guid clientId, Guid characterId, [FromBody, Bind("FirstName, LastName")] Character changedCharacter)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId.ToString())))
                return Forbid();

            Character character = await _repository.GetCharacterByIDAsync(characterId);
            if (character == null)
                return NotFound();
            if (character.ClientID != clientId)
                return Forbid();

            await _repository.UpdateCharacterByIDAsync(characterId, changedCharacter);
            var returnCharacter = await _repository.GetCharacterByIDAsync(characterId);
            return AcceptedAtAction("Get", "Client", null, returnCharacter);
        }

        // DELETE: Delete character: api/clients/{clientId}/characters/{characterId}/delete
        [HttpDelete("{clientId}/characters/{characterId}/delete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Character>> DeleteCharacter(Guid clientId, Guid characterId)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId.ToString())))
                return Forbid();

            Character character = await _repository.GetCharacterByIDAsync(characterId);
            if (character == null)
                return NotFound();
            if (character.ClientID != clientId)
                return Forbid();

            await _repository.DeleteCharacterByIDAsync(characterId);
            return NoContent();
        }
        #endregion

        #region Games
        // POST: Create new game: api/clients/{clientId}/games/new
        [HttpPost("{clientId}/games/new")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Game>> PostGame(Guid clientId, [FromBody, Bind("ClientID, GameName")] Game game)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId.ToString())))
                return Forbid();

            Game newGame = await _repository.CreateGameAsync(game.ClientID, game.GameName);
            return Created($"api/client/{clientId}/games/{newGame.GameID}", newGame);
        }

        // GET: Get client's games: api/clients/{clientId}/games
        [HttpGet("{clientId}/games")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Game>> GetGames(Guid clientId)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId.ToString())))
                return Forbid();

            return Ok(await _repository.GetGamesByClientIDAsync(clientId));
        }

        // GET: Get game info: api/clients/{clientId}/games/{gameId}
        [HttpGet("{clientId}/games/{gameId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Game>> GetGame(Guid clientId, Guid gameId)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId.ToString())))
                return Forbid();

            Game game = await _repository.GetGameByIDAsync(gameId);
            if (game == null)
                return NotFound();
            if (game.ClientID != clientId)
                return Forbid();

            return Ok(game);
        }

        // PUT: Add character to game: api/clients/{clientId}/games/{gameId}/addCharacter/{characterId}
        [HttpPut("{clientId}/games/{gameId}/addCharacter/{characterId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Game>> PutCharacterInGame(Guid clientId, Guid gameId, Guid characterId)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId.ToString())))
                return Forbid();

            Game game = await _repository.GetGameByIDAsync(gameId);
            if (game == null)
                return NotFound();
            if (game.ClientID != clientId)
                return Forbid();

            Character character = await _repository.GetCharacterByIDAsync(characterId);
            if (character == null)
                return NotFound();

            if (!game.Characters.Exists(c => c.CharacterID == character.CharacterID))
            {
                await _repository.UpdateGameAsync(gameId, game);
                var returnGame = await _repository.GetGameByIDAsync(gameId);
                return AcceptedAtAction("Get", "Client", null, returnGame);
            }
            else return BadRequest("Character already exists in game.");
        }


        // PUT: Update game info: api/clients/{clientId}/games/{gameId}/update
        [HttpPut("{clientId}/games/{gameId}/update")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Game>> PutGame(Guid clientId, Guid gameId, [FromBody, Bind("GameName")] Game changedGame)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId.ToString())))
                return Forbid();

            Game game = await _repository.GetGameByIDAsync(gameId);
            if (game.ClientID != clientId)
                return Forbid();

            await _repository.UpdateGameAsync(gameId, changedGame);
            var returnGame = await _repository.GetGameByIDAsync(gameId);
            return AcceptedAtAction("Get", "Client", null, returnGame);
        }

        // DELETE: Delete game: api/clients/{clientId}/games/{gameId}/delete
        [HttpDelete("{clientId}/games/{gameId}/delete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Game>> DeleteGame(Guid clientId, Guid gameId)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId.ToString())))
                return Forbid();

            Game game = await _repository.GetGameByIDAsync(gameId);
            if (game.ClientID != clientId)
                return Forbid();

            await _repository.DeleteGameByIDAsync(gameId);
            return NoContent();
        }
        #endregion

        #region Overview
        // POST Create overview: api/client/{clientId}/games/{gameId}/overviews/new
        [HttpPost("{clientId}/games/{gameId}/overviews/new")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Overview>> PostOverview(Guid clientId, Guid gameId, [FromBody, Bind("Name, Content")] Overview overview)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId.ToString())))
                return Forbid();

            Game game = await _repository.GetGameByIDAsync(gameId);
            if (game == null)
                return NotFound();
            if (game.ClientID != clientId)
                return Forbid();

            Overview newOverview = await _repository.CreateOverviewAsync(gameId, overview.Name, overview.Content);
            return Created($"api/client/{clientId}/games/{gameId}/overviews/{newOverview.OverviewID}", newOverview);
        }

        // GET Get all overviews of a game: api/client/{clientId}/games/{gameId}/overviews
        [HttpGet("{clientId}/games/{gameId}/overviews")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Overview>> GetOveview(Guid clientId, Guid gameId)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId.ToString())))
                return Forbid();

            Game game = await _repository.GetGameByIDAsync(gameId);
            if (game == null)
                return NotFound();
            if (game.ClientID != clientId)
                return Forbid();

            return Ok(game.Overviews);
        }

        // GET Get overview info: api/client/{clientId}/games/{gameId}/overviews/{overviewId}
        [HttpGet("{clientId}/games/{gameId}/overviews/{overviewId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Overview>> GetOveview(Guid clientId, Guid gameId, Guid overviewId)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId.ToString())))
                return Forbid();

            Game game = await _repository.GetGameByIDAsync(gameId);
            if (game == null)
                return NotFound();
            if (game.ClientID != clientId)
                return Forbid();

            return Ok(await _repository.GetOverviewByIDAsync(overviewId));
        }

        // PUT Update overview: api/client/{clientId}/games/{gameId}/overviews/update/{overviewId}
        [HttpPut("api/client/{clientId}/games/{gameId}/overviews/{overviewId}/update")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Overview>> PutOverview(Guid clientId, Guid gameId, Guid overviewId, [FromBody, Bind("Name, Content")] Overview changedOverview)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId.ToString())))
                return Forbid();

            Game game = await _repository.GetGameByIDAsync(gameId);
            if (game == null)
                return NotFound();
            if (game.ClientID != clientId)
                return Forbid();

            await _repository.UpdateOverviewByIDAsync(overviewId, changedOverview);
            var returnOverview = await _repository.GetOverviewByIDAsync(overviewId);
            return AcceptedAtAction("Get", "Client", null, returnOverview);
        }

        // DELETE Remove overview: api/client/{clientId}/games/{gameId}/overviews/delete/{overviewId}
        [HttpDelete("{clientId}/games/{gameId}/overviews/{overviewId}/delete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Overview>> DeleteOverview(Guid clientId, Guid gameId, Guid overviewId)
        {
            if (!(await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), clientId.ToString())))
                return Forbid();

            Game game = await _repository.GetGameByIDAsync(gameId);
            if (game == null)
                return NotFound();
            if (game.ClientID != clientId)
                return Forbid();

            await _repository.DeleteOverviewByIDAsync(overviewId);
            return NoContent();
        }
        #endregion
    }
}

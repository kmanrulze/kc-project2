using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dbnd.Api.Models;
using Dbnd.Data.Repository;
using Dbnd.Logic.Interfaces;
using Dbnd.Logic.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dbnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IRepository _repository;

        public GameController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: Game
        [HttpGet]
        public async Task<IEnumerable<Logic.Objects.Game>> Get()
        {
            return await _repository.GetGamesAsync();
        }

        // GET: api/Game/5
        [HttpGet("{id}")]
        public Task<Game> Get(Guid id)
        {
            return _repository.GetGameByGameID(id);
        }

        // GET: api/Game/DungeonMasterID/5
        [HttpGet("DungeonMasterID/{id}")]
        public List<Game> DungeonMasterID(Guid id)
        {
            return _repository.GetGamesByDungeonMasterID(id);
        }

        // Post: api/Game
        [HttpPost]
        public async Task<ActionResult> Post([FromBody, Bind("DungeonMasterID, GameName")] Game game)
        {
            await _repository.CreateGameAsync(game.DungeonMasterID, game.GameName);
            return Created("api/Game/", game);
        }
    }
}
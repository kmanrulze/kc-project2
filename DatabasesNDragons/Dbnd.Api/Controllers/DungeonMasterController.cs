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
    public class DungeonMasterController : Controller
    {
        private readonly IRepository _repository;

        public DungeonMasterController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/DungeonMaster/5
        [HttpGet("{id}")]
        public Task<DungeonMaster> Get(Guid id)
        {
            return _repository.GetDMByDungeonMasterIDAsync(id);
        }

        // GET: api/DungeonMaster/ClientID/5
        [HttpGet("ClientID/{id}")]
        public Task<DungeonMaster> ClientID(Guid id)
        {
            return _repository.GetDMByClientIDAsync(id);
        }

        // Post: api/DungeonMaster
        [HttpPost]
        public ActionResult Post([FromBody, Bind("ClientID")] DungeonMaster dungeonMaster)
        {
            _repository.CreateDungeonMasterAsync(dungeonMaster.ClientID);
            return Created("api/DungeonMaster/", dungeonMaster);
        }
    }
}
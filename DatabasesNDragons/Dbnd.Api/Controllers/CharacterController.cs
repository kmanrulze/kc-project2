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
    public class CharacterController : ControllerBase
    {
        private readonly IRepository _repository;

        public CharacterController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Character
        [HttpGet]
        public IEnumerable<Logic.Objects.Character> Get()
        {   
            return _repository.GetCharacters();
        }

        // GET: api/Character/5
        [HttpGet("{id}")]
        public Task<Character> Get(Guid id)
        {
            return _repository.GetCharacterByCharacterIDAsync(id);
        }

        // POST: api/Character
        [HttpPost]
        public ActionResult Post([FromBody, Bind("ClientID,FirstName,LastName")] Character character)
        {
            _repository.CreateCharacterAsync(character.ClientID, character.FirstName, character.LastName);
            return Created("api/Character/", character);
        }

        // PUT: api/Character/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

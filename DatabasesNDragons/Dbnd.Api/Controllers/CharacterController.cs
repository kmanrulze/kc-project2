using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dbnd.Logic.Interfaces;
using Dbnd.Logic.Objects;
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
        public async Task<IEnumerable<Logic.Objects.Character>> Get()
        {   
            return await _repository.GetCharactersAsync();
        }

        // GET: api/Character/5
        [HttpGet("{id}")]
        public Task<Character> GetCharacter(Guid id)
        {
            return _repository.GetCharacterByCharacterIDAsync(id);
        }

        // POST: api/Character
        [HttpPost]
        public async Task<ActionResult> Post([FromBody, Bind("ClientID,FirstName,LastName")] Character character)
        {
            await _repository.CreateCharacterAsync(character.ClientID, character.FirstName, character.LastName);
            return Created("api/Character/", character);
        }

        // PUT: api/Character/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody, Bind("FirstName, LastName")] Character changedCharacter)
        {
            await _repository.UpdateCharacterByIDAsync(id, changedCharacter);
            var returnCharacter = await _repository.GetCharacterByCharacterIDAsync(id);
            return AcceptedAtAction("Get", "Character", null, returnCharacter);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.DeleteCharacterByIDAsync(id);
            return NoContent();
        }
    }
}

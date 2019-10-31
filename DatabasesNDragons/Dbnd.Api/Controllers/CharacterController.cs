using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dbnd.Data.Repository;
using Dbnd.Api.Models;

namespace Dbnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterListModel _characters;

        public CharacterController(CharacterListModel characters)
        {
            _characters = characters ?? throw new ArgumentNullException(nameof(characters));
        }

        // GET: api/Character
        [HttpGet]
        public IEnumerable<CharacterModel> Get()
        {
            // with a return type like this, ASP.NET choose status code "200" for success,
            // and serializes the return value for the response body.
            return _characters.Characters;
        }

        // GET: api/Character/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Character
        [HttpPost]
        public void Post([FromBody] string value)
        {
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

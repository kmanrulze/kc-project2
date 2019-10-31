using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dbnd.Api.Models;
using Dbnd.Logic.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dbnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        // GET: api/Character
        [HttpGet]
        public IEnumerable<Character> Get()
        {
            Character testChar = new Character
            {
                FirstName = "testfirst",
                LastName ="testlast",
                CharacterID = Guid.NewGuid(),
                ClientID = Guid.NewGuid()
            };
            List<Character> testList = new List<Character>();
            testList.Add(testChar);
            return testList;
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

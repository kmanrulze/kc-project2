using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dbnd.Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dbnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IRepository _repository;

        public ClientController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Client
        [HttpGet]
        public IEnumerable<Logic.Objects.Client> Get()
        {
            return _repository.GetClients();
        }

        // GET: api/Client/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Client
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Client/5
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

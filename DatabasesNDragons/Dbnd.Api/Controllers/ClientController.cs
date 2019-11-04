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
    public class ClientController : ControllerBase
    {
        private readonly IRepository _repository;

        public ClientController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Client
        [HttpGet]
        public async Task<IEnumerable<Logic.Objects.Client>> Get()
        {
            return await _repository.GetClientsAsync();
        }

        //GET: api/Client/5
        [HttpGet("{id}")]
        public Task<Client> Get(Guid id)
        {
            return _repository.GetClientByIDAsync(id);
        }

        // POST: api/Client
        [HttpPost]
        public async Task<ActionResult> Post([FromBody, Bind("UserName, Email")] Client client)
        {
            await _repository.CreateClientAsync(client.UserName, client.Email);
            return Created("api/Client/", client);
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody, Bind("UserName, Email")] Client changedClient)
        {
            await _repository.UpdateClientByIDAsync(id, changedClient);
            var returnClient = await _repository.GetClientByIDAsync(id);
            return AcceptedAtAction("Get", "Client", null, returnClient);
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.DeleteClientByIDAsync(id);
            return NoContent();
        }
    }
}

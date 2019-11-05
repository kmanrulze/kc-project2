using System;
using System.Collections.Generic;
using System.Linq;
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

        public ClientController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Client
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get()
        {
            try
            {
                UserProfile userProfile = JsonConvert.DeserializeObject<UserProfile>(Request.Headers["Profile"]);

                try
                {
                    object rob = new {id = (await _repository.GetClientByEmailAsync(userProfile.email)).ClientID.ToString()};
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

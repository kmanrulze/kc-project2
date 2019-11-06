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
        private IHttpClientFactory _clientFactory;
        private Authorizer _auth;

        public ClientController(IRepository repository, IHttpClientFactory clientFactory)
        {
            _repository = repository;
            _clientFactory = clientFactory;
            _auth = new Authorizer(_clientFactory);
        }
        // GET: api/Client
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get()
        {
            try
            {
                UserProfile userProfile = await _auth.GetUserProfile(Request.Headers["Authorization"].ToString());

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), id.ToString()))
                return Forbid();

            return Ok(_repository.GetClientByIDAsync(id));
        }

        // Not accessible via current flow; deprecated
        // POST: api/Client
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post([FromBody, Bind("UserName, Email")] Client client)
        {
            await _repository.CreateClientAsync(client.UserName, client.Email);
            return Created("api/Client/", client);
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put(Guid id, [FromBody, Bind("UserName, Email")] Client changedClient)
        {
            if (!await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), id.ToString()))
                return Forbid();

            await _repository.UpdateClientByIDAsync(id, changedClient);
            var returnClient = await _repository.GetClientByIDAsync(id);
            return AcceptedAtAction("Get", "Client", null, returnClient);
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!await _auth.Authorized(_repository, Request.Headers["Authorization"].ToString(), id.ToString()))
                return Forbid();

            await _repository.DeleteClientByIDAsync(id);
            return NoContent();
        }
    }
}

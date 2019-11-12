using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using Moq;

using Dbnd.Logic.Objects;
using Dbnd.Api.Controllers;
using System.Net.Http;
using Dbnd.Api;
using Microsoft.AspNetCore.Mvc;

/* FOR FUTURE REFERENCE:
 * Mocking IHttpClientFactory - https://stackoverflow.com/questions/54227487/how-to-mock-the-new-httpclientfactory-in-net-core-2-1-using-moq
 */

namespace Dbnd.Test.API_Tests
{
    public class ClientEndpointTests
    { 
        /* In my haste I forgot what this one was supposed to do so now it just checks the get */
        [Fact]
        public async Task GetSingleClientHasCorrectNameThrows()
        {
            ControllerTestHelper helper = new ControllerTestHelper();
            Guid targetId = helper.Clients[0].ClientID;

            helper.Repository
                .Setup( x => x.GetClientByIDAsync(It.IsAny<Guid>()))
                .Returns(Task.Run( () => helper.Clients.Where(c => c.ClientID == targetId).FirstOrDefault()));

            Assert.NotNull(((await helper.ClientController.GetClient(targetId)).Result as OkObjectResult).Value);
        }

        [Fact]
        public async Task UpdateClientAsyncSuccessfulVerification()
        {
            ControllerTestHelper helper = new ControllerTestHelper();
            Guid targetId = new Guid("8a122045-114d-42c6-8351-df28f6b4339c");
            Client changedClient = new Client();

            helper.Repository
                .Setup(x => x.UpdateClientByIDAsync(It.IsAny<Guid>(), It.IsAny<Client>()))
                    .Returns(Task.FromResult(true))
                    .Verifiable();

            Assert.Null(((await helper.ClientController.GetClient(targetId)).Result as OkObjectResult).Value);
        }

        [Fact]
        public async Task DeleteClientSuccessfulVerification()
        {
            ControllerTestHelper helper = new ControllerTestHelper();
            Guid targetId = new Guid("8a122045-114d-42c6-8351-df28f6b4339c");

            helper.Repository
                .Setup(x => x.DeleteClientByIDAsync(It.IsAny<Guid>()))
                    .Returns(Task.FromResult(true))
                    .Verifiable();

            Assert.Null(((await helper.ClientController.GetClient(targetId)).Result as OkObjectResult).Value);
        }
    }
}

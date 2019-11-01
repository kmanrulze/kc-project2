using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using Moq;

using Dbnd.Logic.Objects;
using Dbnd.Api.Controllers;

namespace Dbnd.Test
{
    public class ClientControllerTests
    {
        // As of writing, ClientController.Get() is not async
        [Fact]
        public void GetAllClientsTestCount()
        {
            var clients = SetUpClients();

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetClients())
                .Returns(() => clients);

            var clientController = new ClientController(mockRepository.Object);

            var listCount = clientController.Get().Count();

            Assert.Equal(3, listCount);
        }

        [Fact]
        public async Task GetSingleClientHasCorrectName()
        {
            var clients = SetUpClients();
            Guid targetId = new Guid("518b9a19-bd55-4497-a01f-2e48f23d8d30");

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup( x => x.GetClientByIDAsync(targetId))
                .Returns(() => Task.Run( () => clients.Where(c => c.clientID == targetId).FirstOrDefault()));

            var clientController = new ClientController(mockRepository.Object);

            var client = await clientController.Get(targetId);

            Assert.Equal("Jacob", client.UserName);
        }

        public List<Client> SetUpClients()
        {
            return new List<Client>
            {
                new Client
                {
                    UserName = "Jacob",
                    Email = "jacobs.email@email.com",
                    clientID = new Guid("518b9a19-bd55-4497-a01f-2e48f23d8d30")
                },
                new Client
                {
                    UserName = "KC",
                    Email = "kcs.email@email.com",
                    clientID = new Guid("01eec648-89c6-4324-a732-165adcd430c6")
                },
                new Client
                {
                    UserName = "Shawn",
                    Email = "shawns.email@email.com",
                    clientID = new Guid("174e181b-f482-4a77-a2c3-734c494616fa")
                }
            };
        }
    }
}

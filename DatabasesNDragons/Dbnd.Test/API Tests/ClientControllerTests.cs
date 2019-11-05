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
        [Fact]
        public async Task GetClientsByEmailAsyncThrowsException()
        {
            var clients = SetUpClients();
            var email = SetUpClients().First().Email;

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetClientByEmailAsync(email))
                .Throws<Exception>();

            await Assert.ThrowsAsync<Exception>(async () => await mockRepository.Object.GetClientByEmailAsync(email));
        }

        [Fact]
        public async Task GetSingleClientHasCorrectName()
        {
            var clients = SetUpClients();
            Guid targetId = new Guid("518b9a19-bd55-4497-a01f-2e48f23d8d30");

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup( x => x.GetClientByIDAsync(targetId))
                .Returns(() => Task.Run( () => clients.Where(c => c.ClientID == targetId).FirstOrDefault()));

            var clientController = new ClientController(mockRepository.Object);

            var client = await clientController.Get(targetId);

            Assert.Equal("Jacob", client.UserName);
        }

        [Fact]
        public async Task CreateClientSuccessfulVerification()
        {
            string userName = "Novum_Usor";
            string email = "Novum_Usor11@email.com";

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.CreateClientAsync(userName, email))
                    .Returns(Task.CompletedTask)
                    .Verifiable();

            var clientController = new ClientController(mockRepository.Object);
            var client = await clientController.Post(new Client(userName, email));

            mockRepository
                .Verify();
        }

        [Fact]
        public async Task UpdateClientAsyncSuccessfulVerification()
        {
            Guid targetId = new Guid("8a122045-114d-42c6-8351-df28f6b4339c");
            Client changedClient = new Client();

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.UpdateClientByIDAsync(targetId, changedClient))
                    .Returns(Task.CompletedTask)
                    .Verifiable();

            var clientController = new ClientController(mockRepository.Object);
            var client = await clientController.Put(targetId, changedClient);

            mockRepository
                .Verify();
        }

        [Fact]
        public async Task DeleteClientSuccessfulVerification()
        {
            Guid targetId = new Guid("8a122045-114d-42c6-8351-df28f6b4339c");

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.DeleteClientByIDAsync(targetId))
                    .Returns(Task.CompletedTask)
                    .Verifiable();

            var clientController = new ClientController(mockRepository.Object);
            var client = await clientController.Delete(targetId);

            mockRepository
                .Verify();
        }

        public List<Client> SetUpClients()
        {
            return new List<Client>
            {
                new Client
                {
                    UserName = "Jacob",
                    Email = "jacobs.email@email.com",
                    ClientID = new Guid("518b9a19-bd55-4497-a01f-2e48f23d8d30")
                },
                new Client
                {
                    UserName = "KC",
                    Email = "kcs.email@email.com",
                    ClientID = new Guid("01eec648-89c6-4324-a732-165adcd430c6")
                },
                new Client
                {
                    UserName = "Shawn",
                    Email = "shawns.email@email.com",
                    ClientID = new Guid("174e181b-f482-4a77-a2c3-734c494616fa")
                }
            };
        }
    }
}

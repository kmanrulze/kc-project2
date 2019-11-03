using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using Moq;

using Dbnd.Logic.Objects;
using Dbnd.Api.Controllers;

namespace Dbnd.Test.API_Tests
{
    public class DungeonMasterControllerTests
    {
        [Fact]
        public async Task GetDMByDungeonMasterIDAsyncHasCorrectID()
        {
            var dms = SetUpDMs();
            Guid targetId = new Guid("e9523ca1-e8da-4de3-bf9c-ab868d9857ae");

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetDMByDungeonMasterIDAsync(targetId))
                .Returns(() => Task.Run(() => dms.Where(c => c.DungeonMasterID == targetId).FirstOrDefault()));

            var dungeonMasterController = new DungeonMasterController(mockRepository.Object);

            var dm = await dungeonMasterController.Get(targetId);

            Assert.Equal(targetId, dm.DungeonMasterID);
        }

        [Fact]
        public async Task GetDMByClientIDAsyncHasCorrectID()
        {
            var dms = SetUpDMs();
            Guid targetId = new Guid("01eec648-89c6-4324-a732-165adcd430c6");

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetDMByClientIDAsync(targetId))
                .Returns(() => Task.Run(() => dms.Where(c => c.ClientID == targetId).FirstOrDefault()));

            var dungeonMasterController = new DungeonMasterController(mockRepository.Object);

            var dm = await dungeonMasterController.ClientID(targetId);

            Assert.Equal(targetId, dm.ClientID);
        }

        [Fact]
        public async Task CreateDungeonMasterAsyncSuccessfulVerification()
        {
            Guid targetId = new Guid("01eec648-89c6-4324-a732-165adcd430c6");
            var newDM = new DungeonMaster(targetId);

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.CreateDungeonMasterAsync(targetId))
                    .Returns(Task.CompletedTask)
                    .Verifiable();

            var dungeonMasterController = new DungeonMasterController(mockRepository.Object);
            var dm = await dungeonMasterController.Post(newDM);

            mockRepository
                .Verify();
        }

        [Fact]
        public async Task DeleteDungeonMasterSuccessfulVerification()
        {
            Guid targetId = new Guid("8a122045-114d-42c6-8351-df28f6b4339c");

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.DeleteDungeonMasterByIDAsync(targetId))
                    .Returns(Task.CompletedTask)
                    .Verifiable();

            var dungeonMasterController = new DungeonMasterController(mockRepository.Object);
            var dungeonMaster = await dungeonMasterController.Delete(targetId);

            mockRepository
                .Verify();
        }

        public List<DungeonMaster> SetUpDMs()
        {
            return new List<DungeonMaster>
            {
                new DungeonMaster
                {
                    DungeonMasterID = new Guid("e9523ca1-e8da-4de3-bf9c-ab868d9857ae"),
                    ClientID = new Guid("518b9a19-bd55-4497-a01f-2e48f23d8d30")
                },
                new DungeonMaster
                {
                    DungeonMasterID = new Guid("c96a7da6-4e4e-4adb-8d9b-e1d7cb3c5341"),
                    ClientID = new Guid("01eec648-89c6-4324-a732-165adcd430c6")
                },
                new DungeonMaster
                {
                    DungeonMasterID = new Guid("178c8901-cd07-4d15-9454-d96ab325ecbf"),
                    ClientID = new Guid("174e181b-f482-4a77-a2c3-734c494616fa")
                }
            };
        }
    }
}

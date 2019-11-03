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
    public class GameControllerTests
    {
        [Fact]
        public async Task GetGameAsyncTestCount()
        {
            var games = SetUpGames();

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetGamesAsync())
                .Returns( async () => await Task.Run( () => games.AsEnumerable() ));

            var gameController = new GameController(mockRepository.Object);

            var ienumReturn = await gameController.Get();
            var listCount = ienumReturn.ToList().Count();

            Assert.Equal(3, listCount);
        }

        [Fact]
        public async Task GetSingleGameHasCorrectID()
        {
            var games = SetUpGames();
            Guid targetId = new Guid("32f71873-125e-46b3-ade7-17b3e4fb936b");

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetGameByGameIDAsync(targetId))
                .Returns(() => Task.Run(() => games.Where(c => c.GameID == targetId).FirstOrDefault()));

            var gameController = new GameController(mockRepository.Object);

            var game = await gameController.Get(targetId);

            Assert.Equal(targetId, game.GameID);
        }

        [Fact]
        public async Task GetSingleGameByDMIDHasCorrectCount()
        {
            var games = SetUpGames();
            Guid targetId = new Guid("2700fb0f-820d-4be6-9ea3-402fe335f57d");

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetGamesByDungeonMasterIDAsync(targetId))
                .Returns(async () => await Task.Run( () => games.Where(c => c.DungeonMasterID == targetId).ToList()));

            var gameController = new GameController(mockRepository.Object);

            var ienumReturn = await gameController.DungeonMasterID(targetId);
            var listCount = ienumReturn.ToList().Count();

            Assert.Equal(2, listCount);
        }

        [Fact]
        public async Task CreateGameSuccessfulVerification()
        {
            Guid targetId = new Guid("8a122045-114d-42c6-8351-df28f6b4339c");
            string targetName = "Novum_Ludum";
            var newGame = new Game(targetId, targetName);

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.CreateGameAsync(targetId, targetName))
                    .Returns(Task.CompletedTask)
                    .Verifiable();

            var gameController = new GameController(mockRepository.Object);
            var game = await gameController.Post(newGame);

            mockRepository
                .Verify();
        }

        [Fact]
        public async Task UpdateGameAsyncSuccessfulVerification()
        {
            Guid targetId = new Guid("8a122045-114d-42c6-8351-df28f6b4339c");
            Game changedGame = new Game();

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.UpdateGameAsync(targetId, changedGame))
                    .Returns(Task.CompletedTask)
                    .Verifiable();

            var gameController = new GameController(mockRepository.Object);
            var game = await gameController.Put(targetId, changedGame);

            mockRepository
                .Verify();
        }

        [Fact]
        public async Task DeleteGameSuccessfulVerification()
        {
            Guid targetId = new Guid("8a122045-114d-42c6-8351-df28f6b4339c");

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.DeleteGameByIDAsync(targetId))
                    .Returns(Task.CompletedTask)
                    .Verifiable();

            var gameController = new GameController(mockRepository.Object);
            var game = await gameController.Delete(targetId);

            mockRepository
                .Verify();
        }

        public List<Game> SetUpGames()
        {
            return new List<Logic.Objects.Game>
            {
                new Logic.Objects.Game()
                {
                    GameName = "EyeOfTheBeHolder",
                    DungeonMasterID = new Guid("2700fb0f-820d-4be6-9ea3-402fe335f57d"),
                    GameID = new Guid("32f71873-125e-46b3-ade7-17b3e4fb936b")
                },
                new Logic.Objects.Game()
                {
                    GameName = "NeverwinterNights",
                    DungeonMasterID = new Guid("2700fb0f-820d-4be6-9ea3-402fe335f57d"),
                    GameID = Guid.NewGuid()
                },
                new Dbnd.Logic.Objects.Game()
                {
                    GameName = "DrunkenCampFireFollies",
                    DungeonMasterID = Guid.NewGuid(),
                    GameID = Guid.NewGuid()
                }
            };
        }
    }
}

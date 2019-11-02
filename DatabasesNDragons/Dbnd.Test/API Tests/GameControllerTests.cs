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
        public void GetGameTestCount()
        {
            var games = SetUpGames();

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetGames())
                .Returns(() => games);

            var gameController = new GameController(mockRepository.Object);

            var listCount = gameController.Get().Count();

            Assert.Equal(3, listCount);

        }

        [Fact]
        public async Task GetSingleGameHasCorrectID()
        {
            var games = SetUpGames();
            Guid targetId = new Guid("32f71873-125e-46b3-ade7-17b3e4fb936b");

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetGameByGameID(targetId))
                .Returns(() => Task.Run(() => games.Where(c => c.GameID == targetId).FirstOrDefault()));

            var gameController = new GameController(mockRepository.Object);

            var game = await gameController.Get(targetId);

            Assert.Equal(targetId, game.GameID);
        }

        [Fact]
        public void GetSingleGameByDMIDHasCorrectCount()
        {
            var games = SetUpGames();
            Guid targetId = new Guid("2700fb0f-820d-4be6-9ea3-402fe335f57d");

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetGamesByDungeonMasterID(targetId))
                .Returns(() => games.Where(c => c.DungeonMasterID == targetId).ToList());

            var gameController = new GameController(mockRepository.Object);

            var game = gameController.DungeonMasterID(targetId);

            Assert.Equal(2, game.Count());
        }

        [Fact]
        public async Task CreateGameSuccessfulCallCount()
        {
            var games = SetUpGames();
            Guid targetId = new Guid("8a122045-114d-42c6-8351-df28f6b4339c");
            string targetName = "Novum_Ludum";

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.CreateGameAsync(targetId, targetName));

            await mockRepository.Object.CreateGameAsync(targetId, targetName);

            mockRepository
                .Verify(x => x.CreateGameAsync(targetId, targetName), Times.Once());
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

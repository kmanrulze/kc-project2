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

namespace Dbnd.Test.API_Tests
{
    public class GameEndpointTests
    {
        [Fact]
        public async Task GetSingleGameHasCorrectID()
        {
            ControllerTestHelper helper = new ControllerTestHelper();
            Guid targetClientId = helper.Games[0].ClientID;
            Guid targetGameId = helper.Games[0].GameID;

            helper.Repository.Setup(x => x.GetGameByIDAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(helper.Games[0]))
                .Verifiable();

            Game game = (Game)((await helper.ClientController.GetGame(targetClientId, targetGameId)).Result as OkObjectResult).Value;

            Assert.Equal(targetGameId, game.GameID);
        }

        [Fact]
        public async Task CreateGameSuccessfulVerification()
        {
            ControllerTestHelper helper = new ControllerTestHelper();
            string targetName = "Novum_Ludum";
            var newGame = new Game(helper.Clients[0].ClientID, targetName);
            Guid targetClientId = helper.Clients[0].ClientID;

            helper.Repository.Setup(x => x.CreateGameAsync(It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(Task.FromResult(newGame))
                .Verifiable();

            Game game = (Game)((await helper.ClientController.PostGame(targetClientId, newGame)).Result as CreatedResult).Value;

            helper.Repository.Verify();
            Assert.NotNull(game);
        }

        [Fact]
        public async Task UpdateGameAsyncSuccessfulVerification()
        {
            ControllerTestHelper helper = new ControllerTestHelper();
            Guid targetClientId = helper.Clients[0].ClientID;
            Guid targetGameId = helper.Games[0].GameID;
            Game changedGame = new Game();

            helper.Repository.Setup(x => x.GetGameByIDAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(helper.Games[0]))
                .Verifiable();
            helper.Repository.Setup(x => x.UpdateGameAsync(It.IsAny<Guid>(), It.IsAny<Game>()))
                .Returns(Task.FromResult(true))
                .Verifiable();

            Game game = (Game)((await helper.ClientController.PutGame(targetClientId, targetGameId, changedGame)).Result as AcceptedAtActionResult).Value;

            helper.Repository.Verify();
            Assert.NotNull(game);
        }

        [Fact]
        public async Task DeleteGameSuccessfulVerification()
        {
            ControllerTestHelper helper = new ControllerTestHelper();
            Guid targetClientId = helper.Games[0].ClientID;
            Guid targetGameId = helper.Games[0].GameID;

            helper.Repository.Setup(x => x.GetGameByIDAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(helper.Games[0]))
                .Verifiable();
            helper.Repository.Setup(x => x.DeleteGameByIDAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(true))
                .Verifiable();

            var result = await helper.ClientController.DeleteGame(targetClientId, targetGameId);

            helper.Repository.Verify();
        }
    }
}

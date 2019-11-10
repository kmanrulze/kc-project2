using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using Moq;

using Dbnd.Logic.Objects;
using Dbnd.Api.Controllers;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Dbnd.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Components;

namespace Dbnd.Test.API_Tests
{
    public class CharacterEndpointTests
    {
        [Fact]
        public async Task GetCharacterByCharacterIDAsyncHasCorrectID()
        {
            ControllerTestHelper helper = new ControllerTestHelper();

            Guid targetClientId = helper.Clients[0].ClientID;
            Guid targetCharacterId = helper.Clients[0].Characters[0].CharacterID;

            helper.Repository
                .Setup(x => x.GetCharacterByIDAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(helper.Clients[0].Characters[0]));

            Character character = (Character)((await helper.ClientController.GetCharacter(targetClientId, targetCharacterId)).Result as OkObjectResult).Value;

            Assert.Equal(targetCharacterId, character.CharacterID);
        }

        [Fact]
        public async Task CreateCharacterAsyncSuccessfulVerification()
        {
            ControllerTestHelper helper = new ControllerTestHelper();

            Guid targetClientId = helper.Clients[0].ClientID;
            string targetFirstName = "Novum";
            string targetLastName = "Ingenium";

            var newCharacter = new Character(targetClientId, targetFirstName, targetLastName);
            Guid targetCharacterId = newCharacter.CharacterID;

            helper.Repository
                .Setup(x => x.CreateCharacterAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>()))
                    .Returns(Task.FromResult(newCharacter))
                    .Verifiable();

            var character = await helper.ClientController.PostCharacter(targetClientId, newCharacter);

            helper.Repository
                .Verify();
        }

        [Fact]
        public async Task UpdateCharacterAsyncSuccessfulVerification()
        {
            ControllerTestHelper helper = new ControllerTestHelper();

            Guid targetClientId = helper.Clients[0].ClientID;
            Guid targetCharacterId = helper.Clients[0].Characters[0].CharacterID;
            Character changedCharacter = new Character();

            helper.Repository
                .Setup(x => x.GetCharacterByIDAsync(It.IsAny<Guid>()))
                    .Returns(Task.FromResult(helper.Clients[0].Characters[0]))
                    .Verifiable();
            helper.Repository
                .Setup(x => x.UpdateCharacterByIDAsync(It.IsAny<Guid>(), It.IsAny<Character>()))
                    .Returns(Task.FromResult(true))
                    .Verifiable();

            var character = await helper.ClientController.PutCharacter(targetClientId, targetCharacterId, changedCharacter);

            helper.Repository
                .Verify();
        }

        [Fact]
        public async Task DeleteCharacterAsyncSuccessfulVerification()
        {
            ControllerTestHelper helper = new ControllerTestHelper();

            Guid targetClientId = helper.Clients[0].ClientID;
            Guid targetCharacterId = helper.Clients[0].Characters[0].CharacterID;

            helper.Repository
                .Setup(x => x.GetCharacterByIDAsync(It.IsAny<Guid>()))
                    .Returns(Task.FromResult(helper.Clients[0].Characters[0]))
                    .Verifiable();
            helper.Repository
                .Setup(x => x.DeleteCharacterByIDAsync(It.IsAny<Guid>()))
                    .Returns(Task.FromResult(true))
                    .Verifiable();

            var character = await helper.ClientController.DeleteCharacter(targetClientId, targetCharacterId);

            helper.Repository
                .Verify();
        }
    }
}

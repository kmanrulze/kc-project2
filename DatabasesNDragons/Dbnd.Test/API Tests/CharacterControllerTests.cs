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
    public class CharacterControllerTests
    {
        /*[Fact]
        public async Task GetCharactersTestCount()
        {
            var characters = SetUpCharacters();

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetCharactersAsync())
                .Returns(() => Task.Run(() => characters.AsEnumerable()));

            var characterController = new CharacterController(mockRepository.Object);

            var ienumReturn = await characterController.Get();
            var listCount = ienumReturn.ToList().Count();

            Assert.Equal(3, listCount);
        }*/

        [Fact]
        public async Task GetCharacterByCharacterIDAsyncHasCorrectID()
        {
            var characters = SetUpCharacters();
            Guid targetId = new Guid("d9beb26e-11e5-490f-a27f-1467ac5d6a68");

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetCharacterByIDAsync(targetId))
                .Returns(async () => await Task.Run(() => characters.Where(c => c.CharacterID == targetId).FirstOrDefault()));

            var characterController = new CharacterController(mockRepository.Object);

            var character = await characterController.GetCharacter(targetId);

            Assert.Equal(targetId, character.CharacterID);
        }

        [Fact]
        public async Task CreateCharacterAsyncSuccessfulVerification()
        {
            Guid targetId = new Guid("8a122045-114d-42c6-8351-df28f6b4339c");
            string targetFirstName = "Novum";
            string targetLastName = "Ingenium";
            var newCharacter = new Character(targetId, targetFirstName, targetLastName);

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.CreateCharacterAsync(targetId, targetFirstName, targetLastName))
                    .Returns(Task.FromResult(true))
                    .Verifiable();

            var characterController = new CharacterController(mockRepository.Object);
            var character = await characterController.Post(newCharacter);

            mockRepository
                .Verify();
        }

        [Fact]
        public async Task UpdateCharacterAsyncSuccessfulVerification()
        {
            Guid targetId = new Guid("8a122045-114d-42c6-8351-df28f6b4339c");
            Character changedCharacter = new Character();

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.UpdateCharacterByIDAsync(targetId, changedCharacter))
                    .Returns(Task.FromResult(true))
                    .Verifiable();

            var characterController = new CharacterController(mockRepository.Object);
            var character = await characterController.Put(targetId, changedCharacter);

            mockRepository
                .Verify();
        }

        [Fact]
        public async Task DeleteCharacterAsyncSuccessfulVerification()
        {
            Guid targetId = new Guid("8a122045-114d-42c6-8351-df28f6b4339c");

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.DeleteCharacterByIDAsync(targetId))
                    .Returns(Task.FromResult(true))
                    .Verifiable();

            var characterController = new CharacterController(mockRepository.Object);
            var character = await characterController.Delete(targetId);

            mockRepository
                .Verify();
        }

        public List<Character> SetUpCharacters()
        {
            return new List<Logic.Objects.Character>
            {
                new Logic.Objects.Character()
                {
                    CharacterID = new Guid("d9beb26e-11e5-490f-a27f-1467ac5d6a68"),
                    ClientID = new Guid("32f71873-125e-46b3-ade7-17b3e4fb936b"),
                    FirstName = "Willy",
                    LastName = "Wonka"
                },
                new Logic.Objects.Character()
                {
                    ClientID = new Guid("2700fb0f-820d-4be6-9ea3-402fe335f57d"),
                    FirstName = "Skip",
                    LastName = "Donahue"
                },
                new Dbnd.Logic.Objects.Character()
                {
                    ClientID = new Guid("3b5db8e2-466a-4972-983d-5679120fe589"),
                    FirstName = "Leo",
                    LastName = "Bloom"
                }
            };
        }
    }
}

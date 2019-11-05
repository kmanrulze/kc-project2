using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using Moq;

namespace Dbnd.Test
{
    public class DataRepositoryTests
    {

        [Fact]
        public async Task GetAllGamesByDungeonMasterIDAsyncHasCorrectCountIDInDBAsync()
        {
            var listOfGames = SetUpGames();
            var testDungeonMasterID = listOfGames.First().DungeonMasterID;
            
            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetGamesByDungeonMasterIDAsync(testDungeonMasterID))
                .Returns(async () => await Task.Run( () => listOfGames.Where(x => x.DungeonMasterID == testDungeonMasterID).ToList()));

            var ienumList = await mockRepository.Object.GetGamesByDungeonMasterIDAsync(testDungeonMasterID);
            var listCount = ienumList.Count();

            Assert.Equal(2, listCount);
        }

        [Fact]
        public async Task GetAllGamesByDungeonMasterIDAsyncHasCorrectCountIDNotInDBAsync()
        {
            var testDungeonMasterID = Guid.NewGuid();
            var listOfGames = SetUpGames();

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetGamesByDungeonMasterIDAsync(testDungeonMasterID))
                .Returns(async () => await Task.Run( () => listOfGames.Where(x => x.DungeonMasterID == testDungeonMasterID).ToList()));

            var ienumList = await mockRepository.Object.GetGamesByDungeonMasterIDAsync(testDungeonMasterID);
            var listCount = ienumList.Count();

            Assert.Equal(0, listCount);
        }

        [Fact]
        public async Task GetCharacterByCharacterIDAsyncIDInDbReturnsCorrectCharacter()
        {
            var listOfCharacters = SetupCharacters();
            var testCharacterID = listOfCharacters.First().CharacterID;

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetCharacterByCharacterIDAsync(testCharacterID))
                .Returns(() => Task.FromResult(listOfCharacters.Where(x => x.CharacterID == testCharacterID).Single()));

            var testCharacter = await mockRepository.Object.GetCharacterByCharacterIDAsync(testCharacterID);

            Assert.Equal(testCharacterID.ToString(), testCharacter.CharacterID.ToString());
        }

        [Fact]
        public async Task GetCharacterByCharacterIDAsyncNoCharacterIDInDBReturnsException()
        {
            var testCharacterID = Guid.NewGuid();

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetCharacterByCharacterIDAsync(testCharacterID))
                .Returns( () => null);

            await Assert.ThrowsAsync<NullReferenceException>(async () => await mockRepository.Object.GetCharacterByCharacterIDAsync(testCharacterID));
        }

        [Fact]
        public async Task CreateCharacterAsyncSuccess()
        {
            var characterID = Guid.NewGuid();
            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.CreateCharacterAsync(characterID, "Kimmuriel", "Oblodra"));

            await mockRepository.Object.CreateCharacterAsync(characterID, "Kimmuriel", "Oblodra");
            
            mockRepository
                .Verify(x => x.CreateCharacterAsync(characterID, "Kimmuriel", "Oblodra"), Times.Once());
        }

        [Fact]
        public async Task UpdateCharacterByIDAsyncGetsCalledOnce()
        {
            
            var listOfCharacters = SetupCharacters();
            var targetID = listOfCharacters.First().CharacterID;
            var changedCharacter = new Logic.Objects.Character()
            {
                FirstName = "Mutata",
                LastName = "Cognomen"
            };

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.UpdateCharacterByIDAsync(targetID, changedCharacter));

            await mockRepository.Object.UpdateCharacterByIDAsync(targetID, changedCharacter);

            mockRepository
                .Verify(x => x.UpdateCharacterByIDAsync(targetID, changedCharacter), Times.Once());
        }

        [Fact]
        public async Task DeleteCharacterByIDAsyncGetsCalledOnce()
        {

            var listOfCharacters = SetupCharacters();
            var targetID = listOfCharacters.First().CharacterID;

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.DeleteCharacterByIDAsync(targetID));

            await mockRepository.Object.DeleteCharacterByIDAsync(targetID);

            mockRepository
                .Verify(x => x.DeleteCharacterByIDAsync(targetID), Times.Once());
        }

        [Fact]
        public async Task GetDMbyDungeonMasterIDAsyncIdinDbReturnsCorrectDungeonMaster()
        {
            var listOfDungeonMasters = SetupDungeonMasters();
            var testDungeonMasterID = listOfDungeonMasters.First().DungeonMasterID;
            
            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetDMByDungeonMasterIDAsync(testDungeonMasterID))
                .Returns(() => Task.FromResult(listOfDungeonMasters.Where(x => x.DungeonMasterID == testDungeonMasterID).Single()));

            var testDungeonMaster = (await mockRepository.Object.GetDMByDungeonMasterIDAsync(testDungeonMasterID));

            Assert.Equal(testDungeonMasterID.ToString(), testDungeonMaster.DungeonMasterID.ToString());
        }

        [Fact]
        public async Task GetDMbyDungeonMasterIDAsyncIdThrowsException()
        {
            var testDungeonMasterID = Guid.NewGuid();

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetDMByDungeonMasterIDAsync(testDungeonMasterID))
                .Throws<Exception>();

            await Assert.ThrowsAsync<Exception>(async () => await mockRepository.Object.GetDMByDungeonMasterIDAsync(testDungeonMasterID));
        }

        [Fact]
        public async Task CreateDungeonMasterAsyncSuccess()
        {
            var clientID = Guid.NewGuid();
            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.CreateDungeonMasterAsync(clientID));

            await mockRepository.Object.CreateDungeonMasterAsync(clientID);

            mockRepository
                .Verify(x => x.CreateDungeonMasterAsync(clientID), Times.Once());
        }

        [Fact]
        public async Task DeleteDungeonMasterByIDAsyncGetsCalledOnce()
        {

            var listOfDungeonMasters = SetupDungeonMasters();
            var targetID = listOfDungeonMasters.First().DungeonMasterID;

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.DeleteDungeonMasterByIDAsync(targetID));

            await mockRepository.Object.DeleteDungeonMasterByIDAsync(targetID);

            mockRepository
                .Verify(x => x.DeleteDungeonMasterByIDAsync(targetID), Times.Once());
        }

        [Fact]
        public async Task GetGameByGameId()
        {
            var listOfGames = SetUpGames();
            var targetID = listOfGames.First().GameID;


            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetGameByGameIDAsync(targetID))
                .Returns(() => Task.FromResult(listOfGames.Where(x => x.GameID == targetID).Single()));

            var testGame = (await mockRepository.Object.GetGameByGameIDAsync(targetID));

            Assert.Equal(targetID.ToString(), testGame.GameID.ToString());
        }

        [Fact]
        public async Task GetGameByGameIdIDNotInDB()
        {
            var listOfGames = SetUpGames();
            var targetID = Guid.NewGuid();

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetGameByGameIDAsync(targetID))
                .Throws<Exception>();

            await Assert.ThrowsAsync<Exception>(async () => await mockRepository.Object.GetGameByGameIDAsync(targetID));
        }

        [Fact]
        public async Task CreateGameAsyncSuccess()
        {
            var dungeonMasterID = Guid.NewGuid();
            var gameName = "GameOfPhonesDLC";
            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.CreateGameAsync(dungeonMasterID, gameName));

            await mockRepository.Object.CreateGameAsync(dungeonMasterID, gameName);

            mockRepository
                .Verify(x => x.CreateGameAsync(dungeonMasterID, gameName), Times.Once());
        }

        [Fact]
        public async Task GetClientByEmailAsyncIDInDbReturnsCorrectClient()
        {
            var listOfClients = SetupClients();
            var targetID = listOfClients.First().Email;

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetClientByEmailAsync(targetID))
                .Returns(() => Task.FromResult(listOfClients.Where(x => x.Email == targetID).Single()));

            var testClient = (await mockRepository.Object.GetClientByEmailAsync(targetID));

            Assert.Equal(targetID, testClient.Email);
        }

        [Fact]
        public async Task GetClientByEmailAsyncIDNotInDbReturnsCorrectClient()
        {
            var listOfClients = SetupClients();
            var targetID = "notallhere@gamil.com";

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetClientByEmailAsync(targetID))
                .Throws<Exception>();

            await Assert.ThrowsAsync<Exception>(async () => await mockRepository.Object.GetClientByEmailAsync(targetID));
        }

        [Fact]
        public async Task GetClientByIDAsyncIDInDbReturnsCorrectClient()
        {
            var listOfClients = SetupClients();
            var targetID = listOfClients.First().ClientID;

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetClientByIDAsync(targetID))
                .Returns(() => Task.FromResult(listOfClients.Where(x => x.ClientID == targetID).Single()));

            var testClient = (await mockRepository.Object.GetClientByIDAsync(targetID));

            Assert.Equal(targetID.ToString(), testClient.ClientID.ToString());
        }

        [Fact]
        public async Task GetClientByIDAsyncIDNotInDBReturnsCorrectClient()
        {
            var listOfClients = SetupClients();
            var targetID = Guid.NewGuid();


            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetClientByIDAsync(targetID))
                .Throws<Exception>();

            await Assert.ThrowsAsync<Exception>(async () => await mockRepository.Object.GetClientByIDAsync(targetID));
        }
        [Fact]
        public async Task CreateClientAsyncSuccess()
        {
            var userName = "DnDDynomite";
            var email = "DnDDynomite@gmail.com";
            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.CreateClientAsync(userName, email));

            await mockRepository.Object.CreateClientAsync(userName, email);

            mockRepository
                .Verify(x => x.CreateClientAsync(userName, email), Times.Once());
        }

        [Fact]
        public async Task UpdateClientByIDAsyncGetsCalledOnce()
        {

            var listOfClients = SetupClients();
            var targetID = listOfClients.First().ClientID;
            var changedClient = new Logic.Objects.Client()
            {
                UserName = "Mutata",
                Email = "nuntius@email.com"
            };

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.UpdateClientByIDAsync(targetID, changedClient));

            await mockRepository.Object.UpdateClientByIDAsync(targetID, changedClient);

            mockRepository
                .Verify(x => x.UpdateClientByIDAsync(targetID, changedClient), Times.Once());
        }

        [Fact]
        public async Task DeleteClientByIDAsyncGetsCalledOnce()
        {

            var listOfClients = SetupClients();
            var targetID = listOfClients.First().ClientID;

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.DeleteClientByIDAsync(targetID));

            await mockRepository.Object.DeleteClientByIDAsync(targetID);

            mockRepository
                .Verify(x => x.DeleteClientByIDAsync(targetID), Times.Once());
        }

        public List<Logic.Objects.DungeonMaster> SetupDungeonMasters()
        {
            return new List<Dbnd.Logic.Objects.DungeonMaster>()
                {
                    new Dbnd.Logic.Objects.DungeonMaster()
                    {
                        DungeonMasterID = Guid.NewGuid(),
                        ClientID = Guid.NewGuid()
                    },
                    new Logic.Objects.DungeonMaster()
                    {
                        DungeonMasterID = Guid.NewGuid(),
                        ClientID = Guid.NewGuid()
                    },
                    new Dbnd.Logic.Objects.DungeonMaster()
                    {
                        DungeonMasterID = Guid.NewGuid(),
                        ClientID = Guid.NewGuid()
                    }
                };
        }

        public List<Logic.Objects.Character> SetupCharacters()
        {
            return new List<Logic.Objects.Character>()
            {
                new Dbnd.Logic.Objects.Character()
                {
                    CharacterID = Guid.NewGuid(),
                    FirstName = "Kaanyraa",
                    LastName = "Vhokerson"
                },
                new Logic.Objects.Character()
                {
                    CharacterID = Guid.NewGuid(),
                    FirstName = "Elaithyea",
                    LastName = "Craulnober"
                },
                new Dbnd.Logic.Objects.Character()
                {
                    CharacterID = Guid.NewGuid(),
                    FirstName = "Dinininin",
                    LastName = "DoUrden"
                }
            };
        }

        public List<Logic.Objects.Client> SetupClients()
        {
            return new List<Dbnd.Logic.Objects.Client>()
            {
                new Dbnd.Logic.Objects.Client()
                {
                    ClientID = Guid.NewGuid(),
                    UserName = "DNDBOY4EVR",
                    Email = "DNDBOY4EVER@Gmail.com"
                },
                new Logic.Objects.Client()
                {
                    ClientID = Guid.NewGuid(),
                    UserName = "DNDGURL4EVR",
                    Email = "DNDGURL4EVER@Gmail.com"
                },
                new Dbnd.Logic.Objects.Client()
                {
                    ClientID = Guid.NewGuid(),
                    UserName = "DNDCOWBOY4EVR",
                    Email = "DNDCOWBOY4EVER@Gmail.com"
                }
            };
        }

        public List<Logic.Objects.Game> SetUpGames()
        {
            var sameGuildMasterID = Guid.NewGuid();

            return new List<Dbnd.Logic.Objects.Game>()
            {
                new Dbnd.Logic.Objects.Game()
                {
                    GameName = "EyeOfTheBeHolder",
                    DungeonMasterID = sameGuildMasterID,
                    GameID = Guid.NewGuid()
                },
                new Logic.Objects.Game()
                {
                    GameName = "NeverwinterNights",
                    DungeonMasterID = Guid.NewGuid(),
                    GameID = Guid.NewGuid()
                },
                new Dbnd.Logic.Objects.Game()
                {
                    GameName = "DrunkenCampFireFollies",
                    DungeonMasterID = sameGuildMasterID,
                    GameID = Guid.NewGuid()
                }
            };
        }

    }
}

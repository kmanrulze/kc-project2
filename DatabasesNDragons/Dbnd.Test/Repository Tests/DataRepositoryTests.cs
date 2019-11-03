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
            var testDungeonMasterID = Guid.NewGuid();

            var listOfGames = new List<Dbnd.Logic.Objects.Game>()
            {
                new Dbnd.Logic.Objects.Game()
                {
                    GameName = "EyeOfTheBeHolder",
                    DungeonMasterID = testDungeonMasterID,
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
                    DungeonMasterID = testDungeonMasterID,
                    GameID = Guid.NewGuid()
                }
            };

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

            var listOfGames = new List<Dbnd.Logic.Objects.Game>()
            {
                new Dbnd.Logic.Objects.Game()
                {
                    GameName = "EyeOfTheBeHolder",
                    DungeonMasterID = Guid.NewGuid(),
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
                    DungeonMasterID = Guid.NewGuid(),
                    GameID = Guid.NewGuid()
                }
            };

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
            var testCharacterID = Guid.NewGuid();

            var listOfCharacters = SetupCharacters();

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetCharacterByCharacterIDAsync(testCharacterID))
                .Returns(() => Task.FromResult(listOfCharacters.Where(x => x.CharacterID == testCharacterID).Single()));

            var testCharacter = await mockRepository.Object.GetCharacterByCharacterIDAsync(testCharacterID);

            Assert.Equal(testCharacterID.ToString(), testCharacter.CharacterID.ToString());
        }

        [Fact]
        public async Task GetCharacterByCharacterIDAsyncNoCharacterIDInDBReturnsCorrectCharacter()
        {
            var testCharacterID = Guid.NewGuid();

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetCharacterByCharacterIDAsync(testCharacterID))
                .Throws<Exception>();

            await Assert.ThrowsAsync<Exception>(async () => await mockRepository.Object.GetCharacterByCharacterIDAsync(testCharacterID));
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
            var testDungeonMasterID = Guid.NewGuid();

            var listOfDungeonMasters = new List<Dbnd.Logic.Objects.DungeonMaster>()
                {
                    new Dbnd.Logic.Objects.DungeonMaster()
                    {
                        DungeonMasterID = testDungeonMasterID,
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

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetDMByDungeonMasterIDAsync(testDungeonMasterID))
                .Returns(() => Task.FromResult(listOfDungeonMasters.Where(x => x.DungeonMasterID == testDungeonMasterID).Single()));

            var testDungeonMaster = (await mockRepository.Object.GetDMByDungeonMasterIDAsync(testDungeonMasterID));

            Assert.Equal(testDungeonMasterID.ToString(), testDungeonMaster.DungeonMasterID.ToString());
        }
        [Fact]
        public async Task GetDMbyDungeonMasterIDAsyncIdNotinDbReturnsCorrectDungeonMaster()
        {
            var testDungeonMasterID = Guid.NewGuid();

            var listOfDungeonMasters = new List<Dbnd.Logic.Objects.DungeonMaster>()
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
        public async Task GetGameByGameId()
        {
            var testGameID = Guid.NewGuid();

            var listOfGames = new List<Dbnd.Logic.Objects.Game>()
            {
                new Dbnd.Logic.Objects.Game()
                {
                    GameName = "EyeOfTheBeHolder",
                    DungeonMasterID = Guid.NewGuid(),
                    GameID = testGameID
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
                    DungeonMasterID = Guid.NewGuid(),
                    GameID = Guid.NewGuid()
                }
            };

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetGameByGameIDAsync(testGameID))
                .Returns(() => Task.FromResult(listOfGames.Where(x => x.GameID == testGameID).Single()));

            var testGame = (await mockRepository.Object.GetGameByGameIDAsync(testGameID));

            Assert.Equal(testGameID.ToString(), testGame.GameID.ToString());
        }

        [Fact]
        public async Task GetGameByGameIdIDNotInDB()
        {
            var testGameID = Guid.NewGuid();

            var listOfGames = new List<Dbnd.Logic.Objects.Game>()
            {
                new Dbnd.Logic.Objects.Game()
                {
                    GameName = "EyeOfTheBeHolder",
                    DungeonMasterID = Guid.NewGuid(),
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
                    DungeonMasterID = Guid.NewGuid(),
                    GameID = Guid.NewGuid()
                }
            };

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetGameByGameIDAsync(testGameID))
                .Throws<Exception>();

            await Assert.ThrowsAsync<Exception>(async () => await mockRepository.Object.GetGameByGameIDAsync(testGameID));
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
        public async Task GetClientByIDAsyncIDInDbReturnsCorrectClient()
        {
            var testClientID = Guid.NewGuid();

            var listOfClients = new List<Dbnd.Logic.Objects.Client>()
            {
                new Dbnd.Logic.Objects.Client()
                {
                    ClientID = testClientID,
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

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetClientByIDAsync(testClientID))
                .Returns(() => Task.FromResult(listOfClients.Where(x => x.ClientID == testClientID).Single()));

            var testClient = (await mockRepository.Object.GetClientByIDAsync(testClientID));

            Assert.Equal(testClientID.ToString(), testClient.ClientID.ToString());
        }

        [Fact]
        public async Task GetClientByIDAsyncIDNotInDBReturnsCorrectClient()
        {
            var testClientID = Guid.NewGuid();

            var listOfClients = new List<Dbnd.Logic.Objects.Client>()
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

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetClientByIDAsync(testClientID))
                .Throws<Exception>();

            await Assert.ThrowsAsync<Exception>(async () => await mockRepository.Object.GetClientByIDAsync(testClientID));
        }
        [Fact]
        public async Task CreateClientAsyncSuccess()
        {
            //string userName, string email, string passwordHash

            var userName = "DnDDynomite";
            var email = "DnDDynomite@gmail.com";
            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.CreateClientAsync(userName, email));

            await mockRepository.Object.CreateClientAsync(userName, email);

            mockRepository
                .Verify(x => x.CreateClientAsync(userName, email), Times.Once());
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

    }
}

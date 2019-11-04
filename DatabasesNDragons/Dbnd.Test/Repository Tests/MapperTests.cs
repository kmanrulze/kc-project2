using System;
using Xunit;

namespace Dbnd.Test.Repository_Tests
{
    public class MapperTests
    {
        [Fact]
        public void MapCharacterEntityToObject()
        {
            var clientID = Guid.NewGuid();

            var mappableObject = new Data.Entities.Character()
            {
                FirstName = "Toph",
                LastName = "Beifong",
                ClientID = clientID
            };

            var expected = new Logic.Objects.Character()
            {
                FirstName = "Toph",
                LastName = "Beifong",
                ClientID = clientID
            };

            var value = Data.Repository.Mapper.MapCharacter(mappableObject);

            Assert.IsType<Logic.Objects.Character>(value);
            Assert.IsType<Guid>(value.CharacterID);
            Assert.Equal(expected.FirstName, value.FirstName);
            Assert.Equal(expected.LastName, value.LastName);
            Assert.Equal(expected.ClientID, value.ClientID);

        }

        [Fact]
        public void MapCharacterObjectToEntity()
        {
            var clientID = Guid.NewGuid();

            var mappableObject = new Logic.Objects.Character()
            {
                FirstName = "Toph",
                LastName = "Beifong",
                ClientID = clientID
            };

            var expected = new Data.Entities.Character()
            {
                FirstName = "Toph",
                LastName = "Beifong",
                ClientID = clientID
            };

            var value = Data.Repository.Mapper.MapCharacter(mappableObject);

            Assert.IsType<Data.Entities.Character>(value);
            Assert.IsType<Guid>(value.CharacterID);
            Assert.Equal(expected.FirstName, value.FirstName);
            Assert.Equal(expected.LastName, value.LastName);
            Assert.Equal(expected.ClientID, value.ClientID);
        }

        [Fact]
        public void MapClientEntityToObject()
        {
            var clientID = Guid.NewGuid();

            var mappableObject = new Data.Entities.Client()
            {
                UserName = "Toph",
                Email = "Beifong@email.com"
            };

            var expected = new Logic.Objects.Client()
            {
                UserName = "Toph",
                Email = "Beifong@email.com"
            };

            var value = Data.Repository.Mapper.MapClient(mappableObject);

            Assert.IsType<Logic.Objects.Client>(value);
            Assert.IsType<Guid>(value.ClientID);
            Assert.Equal(expected.UserName, value.UserName);
            Assert.Equal(expected.Email, value.Email);

        }

        [Fact]
        public void MapClientObjectToEntity()
        {
            var clientID = Guid.NewGuid();

            var mappableObject = new Logic.Objects.Client()
            {
                UserName = "Toph",
                Email = "Beifong@email.com"
            };

            var expected = new Data.Entities.Client()
            {
                UserName = "Toph",
                Email = "Beifong@email.com"
            };

            var value = Data.Repository.Mapper.MapClient(mappableObject);

            Assert.IsType<Data.Entities.Client>(value);
            Assert.IsType<Guid>(value.ClientID);
            Assert.Equal(expected.UserName, value.UserName);
            Assert.Equal(expected.Email, value.Email);
        }

        [Fact]
        public void MapDungeonMasterEntityToObject()
        {
            var clientID = Guid.NewGuid();

            var mappableObject = new Data.Entities.DungeonMaster()
            {
                ClientID = clientID
            };

            var expected = new Logic.Objects.DungeonMaster()
            {
                ClientID = clientID
            };

            var value = Data.Repository.Mapper.MapDungeonMaster(mappableObject);

            Assert.IsType<Logic.Objects.DungeonMaster>(value);
            Assert.IsType<Guid>(value.DungeonMasterID);
            Assert.Equal(expected.ClientID, value.ClientID);

        }

        [Fact]
        public void MapDungeonMasterObjectToEntity()
        {
            var clientID = Guid.NewGuid();

            var mappableObject = new Logic.Objects.DungeonMaster()
            {
                ClientID = clientID
            };

            var expected = new Data.Entities.DungeonMaster()
            {
                ClientID = clientID
            };

            var value = Data.Repository.Mapper.MapDungeonMaster(mappableObject);

            Assert.IsType<Data.Entities.DungeonMaster>(value);
            Assert.IsType<Guid>(value.DungeonMasterID);
            Assert.Equal(expected.ClientID, value.ClientID);
        }

        [Fact]
        public void MapGameEntityToObject()
        {
            var dungeonMasterID = Guid.NewGuid();

            var mappableObject = new Data.Entities.Game()
            {
                GameName = "Toph",
                DungeonMasterID = dungeonMasterID
            };

            var expected = new Logic.Objects.Game()
            {
                GameName = "Toph",
                DungeonMasterID = dungeonMasterID
            };

            var value = Data.Repository.Mapper.MapGame(mappableObject);

            Assert.IsType<Logic.Objects.Game>(value);
            Assert.IsType<Guid>(value.GameID);
            Assert.Equal(expected.GameName, value.GameName);
            Assert.Equal(expected.DungeonMasterID, value.DungeonMasterID);

        }

        [Fact]
        public void MapGameObjectToEntity()
        {
            var dungeonMasterID = Guid.NewGuid();

            var mappableObject = new Logic.Objects.Game()
            {
                GameName = "Toph",
                DungeonMasterID = dungeonMasterID
            };

            var expected = new Data.Entities.Game()
            {
                GameName = "Toph",
                DungeonMasterID = dungeonMasterID
            };

            var value = Data.Repository.Mapper.MapGame(mappableObject);

            Assert.IsType<Data.Entities.Game>(value);
            Assert.IsType<Guid>(value.GameID);
            Assert.Equal(expected.GameName, value.GameName);
            Assert.Equal(expected.DungeonMasterID, value.DungeonMasterID);
        }
    }
}

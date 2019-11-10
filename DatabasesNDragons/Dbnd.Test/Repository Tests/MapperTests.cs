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
        public void MapGameEntityToObject()
        {
            var clientID = Guid.NewGuid();

            var mappableObject = new Data.Entities.Game()
            {
                GameName = "Toph",
                ClientID = clientID
            };

            var expected = new Logic.Objects.Game()
            {
                GameName = "Toph",
                ClientID = clientID
            };

            var value = Data.Repository.Mapper.MapGame(mappableObject);

            Assert.IsType<Logic.Objects.Game>(value);
            Assert.IsType<Guid>(value.GameID);
            Assert.Equal(expected.GameName, value.GameName);
            Assert.Equal(expected.ClientID, value.ClientID);

        }

        [Fact]
        public void MapGameObjectToEntity()
        {
            var clientID = Guid.NewGuid();

            var mappableObject = new Logic.Objects.Game()
            {
                GameName = "Toph",
                ClientID = clientID
            };

            var expected = new Data.Entities.Game()
            {
                GameName = "Toph",
                ClientID = clientID
            };

            var value = Data.Repository.Mapper.MapGame(mappableObject);

            Assert.IsType<Data.Entities.Game>(value);
            Assert.IsType<Guid>(value.GameID);
            Assert.Equal(expected.GameName, value.GameName);
            Assert.Equal(expected.ClientID, value.ClientID);
        }

        [Fact]
        public void MapOverviewEntityToObject()
        {
            var gameID = Guid.NewGuid();
            var typeID = Guid.NewGuid();

            var mappableObject = new Data.Entities.Overview()
            {
                TypeID = typeID,
                GameID = gameID
            };

            var expected = new Logic.Objects.Overview()
            {
                TypeID = typeID,
                GameID = gameID
            };

            var value = Data.Repository.Mapper.MapOverview(mappableObject);

            Assert.IsType<Logic.Objects.Overview>(value);
            Assert.IsType<Guid>(value.OverviewID);
            Assert.Equal(expected.TypeID, value.TypeID);
            Assert.Equal(expected.GameID, value.GameID);
        }

        [Fact]
        public void MapOverviewObjectToEntity()
        {
            var gameID = Guid.NewGuid();
            var typeID = Guid.NewGuid();

            var mappableObject = new Logic.Objects.Overview()
            {
                TypeID = typeID,
                GameID = gameID
            };

            var expected = new Data.Entities.Overview()
            {
                TypeID = typeID,
                GameID = gameID
            };

            var value = Data.Repository.Mapper.MapOverview(mappableObject);

            Assert.IsType<Data.Entities.Overview>(value);
            Assert.IsType<Guid>(value.OverviewID);
            Assert.Equal(expected.TypeID, value.TypeID);
            Assert.Equal(expected.GameID, value.GameID);
        }

        /* [Fact]
        public void MapOverviewTypeEntityToObject()
        {
            var gameID = Guid.NewGuid();
            var typeID = Guid.NewGuid();

            var mappableObject = new Data.Entities.OverviewType()
            {
                TypeID = typeID
            };

            var expected = new Logic.Objects.OverviewType()
            {
                TypeID = typeID
            };

            var value = Data.Repository.Mapper.MapOverviewType(mappableObject);

            Assert.IsType<Logic.Objects.OverviewType>(value);
            Assert.IsType<Guid>(value.TypeID);
            Assert.Equal(expected.TypeID, value.TypeID);

        } 

        [Fact]
        public void MapOverviewTypeObjectToEntity()
        {
            var gameID = Guid.NewGuid();
            var typeID = Guid.NewGuid();

            var mappableObject = new Logic.Objects.OverviewType()
            {
                TypeID = typeID
            };

            var expected = new Data.Entities.OverviewType()
            {
                TypeID = typeID
            };

            var value = Data.Repository.Mapper.MapOverviewType(mappableObject);

            Assert.IsType<Data.Entities.OverviewType>(value);
            Assert.IsType<Guid>(value.TypeID);
            Assert.Equal(expected.TypeID, value.TypeID);
        } */
    }
}

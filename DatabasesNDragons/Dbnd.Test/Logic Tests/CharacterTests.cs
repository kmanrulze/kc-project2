using System;
using Xunit;
using Dbnd.Logic.Objects;

namespace Dbnd.Test
{
    public class CharacterTests
    {
        [Fact]
        public void ChangeFirstName()
        {
            Character testCharacter = new Character
            {
                FirstName = "test"
            };
            testCharacter.FirstName = "changed";
            Assert.Equal("changed", testCharacter.FirstName);
        }
        [Fact]
        public void ChangeLastName()
        {
            Character testCharacter = new Character
            {
                LastName = "test"
            };
            testCharacter.LastName = "changed";
            Assert.Equal("changed", testCharacter.LastName);
        }
        [Fact]
        public void TestCharacterGUID()
        {
            Character testCharacter = new Character
            {
                CharacterID = Guid.NewGuid()
            };
            Guid guidResult;
            Assert.True(Guid.TryParse(testCharacter.CharacterID.ToString(), out guidResult));
        }

        [Fact]
        public void TestClientGUID()
        {
            Character testCharacter = new Character
            {
                ClientID = Guid.NewGuid()
            };
            Guid guidResult;
            Assert.True(Guid.TryParse(testCharacter.ClientID.ToString(), out guidResult));
        }

    }
}

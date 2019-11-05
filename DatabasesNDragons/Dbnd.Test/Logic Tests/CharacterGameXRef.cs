using System;
using Xunit;
using Dbnd.Logic.Objects;

namespace Dbnd.Test.Logic_Tests
{
    
    public class CharacterGameXRef
    {
        [Fact]
        public void TestIDForGUID()
        {
            var gameID = Guid.NewGuid();
            var chacacterID = Guid.NewGuid();
            Data.Entities.CharacterGameXRef testXRef = new Data.Entities.CharacterGameXRef()
            {
                CharacterID = chacacterID,
                GameID = gameID
            };
            Guid guidResult;
            Assert.True(Guid.TryParse(testXRef.GameID.ToString(), out guidResult));
            Assert.True(Guid.TryParse(testXRef.CharacterID.ToString(), out guidResult));

        }
    }
}

using System;
using Xunit;
using Dbnd.Logic.Objects;

namespace Dbnd.Test
{
    public class GameTests
    {
        [Fact]
        public void GameNameChanges()
        {
            Game testGame = new Game
            {
                GameName = "test"
            };
            testGame.GameName = "changed";
            Assert.Equal("changed", testGame.GameName);
        }
        [Fact]
        public void TestGUID()
        {
            Game testGame = new Game
            {
                GameID = Guid.NewGuid()
            };
            Guid guidResult;
            Assert.True(Guid.TryParse(testGame.GameID.ToString(), out guidResult));
        }
    }
}

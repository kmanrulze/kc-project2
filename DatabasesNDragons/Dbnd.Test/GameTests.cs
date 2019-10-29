using System;
using System.Collections.Generic;
using System.Text;
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
                GameId = Guid.NewGuid()
            };
            Guid guidResult;
            Assert.True(Guid.TryParse(testGame.GameId.ToString(), out guidResult));
        }
    }
}

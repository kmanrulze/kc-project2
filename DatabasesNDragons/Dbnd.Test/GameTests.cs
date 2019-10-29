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
    }
}

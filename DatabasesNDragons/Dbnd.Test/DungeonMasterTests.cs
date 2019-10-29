using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Dbnd.Logic.Objects;

namespace Dbnd.Test
{
    public class DungeonMasterTests
    {
        [Fact]
        public void CheckAddGame()
        {
            DungeonMaster testDM = new DungeonMaster();
            testDM.Games.Add(new Game());
            Assert.True(testDM.Games.Count == 1);
        }
    }
}

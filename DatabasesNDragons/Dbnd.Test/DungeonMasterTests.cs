using System;
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
        [Fact]
        public void TestGUID()
        {
            DungeonMaster testDM = new DungeonMaster
            {
                DungeonMasterID = Guid.NewGuid()
            };
            Guid guidResult;
            Assert.True(Guid.TryParse(testDM.DungeonMasterID.ToString(), out guidResult));
        }
    }

}

using System;
using Xunit;
using Dbnd.Logic.Objects;

namespace Dbnd.Test.Logic_Tests
{
    public class OverviewTests
    {
        [Fact]
        public void OverviewInitCorrectly()
        {
            var overview = new Overview(Guid.NewGuid(), "test", "");

            Assert.IsType<Guid>(overview.GameID);
            Assert.IsType<Guid>(overview.TypeID);
            Assert.IsType<Guid>(overview.OverviewID);
        }

        [Fact]
        public void OverviewTypeInitCorrectly()
        {
            var overview = new OverviewType();

            Assert.IsType<Guid>(overview.TypeID);
        }
    }
}

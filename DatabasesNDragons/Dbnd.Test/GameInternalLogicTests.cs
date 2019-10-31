using Xunit;
using Dbnd.Logic.Objects;

namespace Dbnd.Test
{
    public class GameInternalLogicTests
    {
        

        [Fact]
        public void RequiredFieldsNotNull_CheckNull()
        {
            Logic.Objects.Game game = new Game();

            var result = game.RequiredFieldsNotNull();

            Assert.True(!result);
        }

        [Fact]
        public void RequiredFieldsNotNull_CheckNotNull()
        {
            Logic.Objects.Game game = new Game()
            {
                GameName = "Realm_Of_QC_Tears"
            };

            var result = game.RequiredFieldsNotNull();

            Assert.True(result);

        }

        [Theory]
        [InlineData("RagnaR444")]
        [InlineData("rrAgN4rr")]
        [InlineData("Rrrrragnar")]
        [InlineData("IAMRAGNAR")]
        public void IsValidGameName_Valid(string gameNameTest)
        {

            Logic.Objects.Game game = new Game
            {
                GameName = gameNameTest
            };

            var result = game.IsValidGameName();

            Assert.True(result);

        }

        [Theory]
        [InlineData("%Ragnar")]
        [InlineData("A4")]
        [InlineData("R")]
        [InlineData("rr@gn@rr")]
        public void IsValidGameName_Invalid(string gameNameTest)
        {

            Logic.Objects.Game game = new Game
            {
                GameName = gameNameTest
            };

            var result = game.IsValidGameName();

            Assert.False(result);

        }
    }
}

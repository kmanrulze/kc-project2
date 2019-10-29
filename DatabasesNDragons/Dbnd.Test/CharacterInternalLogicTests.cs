using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Dbnd.Logic.Objects;

namespace Dbnd.Test
{
    public class CharacterInternalLogicTests
    {
        

        [Fact]
        public void RequiredFieldsNotNull_CheckNull()
        {
            Logic.Objects.Character character = new Character();

            var result = character.RequiredFieldsNotNull();

            Assert.True(!result);
        }

        [Fact]
        public void RequiredFieldsNotNull_CheckNotNull()
        {
            Logic.Objects.Character character = new Character
            {
                FirstName = "Ragnar",
                LastName = "Lodbrok"
            };

            var result = character.RequiredFieldsNotNull();

            Assert.True(result);

        }

        [Theory]
        [InlineData("RagnaR444")]
        [InlineData("rrAgN4rr")]
        [InlineData("Rrrrragnar")]
        [InlineData("IAMRAGNAR")]
        public void IsValidFirstName_Valid(string firstNameTest)
        {

            Logic.Objects.Character character = new Character
            {
                FirstName = firstNameTest,
                LastName = "Lodbrok"
            };

            var result = character.IsValidFirstName();

            Assert.True(result);

        }

        [Theory]
        [InlineData("%Ragnar")]
        [InlineData("AgN4r")]
        [InlineData("R")]
        [InlineData("rr@gn@rr")]
        public void IsValidFirstName_Invalid(string firstNameTest)
        {

            Logic.Objects.Character character = new Character
            {
                FirstName = firstNameTest,
                LastName = "Lodbrok"
            };

            var result = character.IsValidFirstName();

            Assert.True(!result);

        }

        [Theory]
        [InlineData("Lodbrok")]
        [InlineData("l0Brkok")]
        [InlineData("LoBrOk")]
        [InlineData("IAMRAGNAR")]
        public void IsValidLastName_Valid(string lastNameTest)
        {

            Logic.Objects.Character character = new Character
            {
                FirstName = "Ragnar",
                LastName = lastNameTest
            };

            var result = character.IsValidLastName();

            Assert.True(result);

        }

        [Theory]
        [InlineData("%Ragnar")]
        [InlineData("AgN4r")]
        [InlineData("R")]
        [InlineData("rr@gn@rr")]
        public void IsValidLastName_Invalid(string lastNameTest)
        {

            Logic.Objects.Character character = new Character
            {
                FirstName = "Ragnar",
                LastName = lastNameTest
            };

            var result = character.IsValidLastName();

            Assert.True(!result);

        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
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
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Dbnd.Logic.Objects;

namespace Dbnd.Test
{
    public class InternalLogicTests
    {
        

        [Fact]
        public void RequiredFieldsNotNull_CheckNull()
        {
            Logic.Objects.Client client = new Client();

            var result = client.RequiredFieldsNotNull();

            Assert.True(!result);

        }

        [Fact]
        public void RequiredFieldsNotNull_CheckNotNull()
        {
            Logic.Objects.Client client = new Client
            {
                UserName = "DnDMan13",
                Email = "DnDMan13@yahoo.com",
                PasswordHash = "Password1234"
            };

            var result = client.RequiredFieldsNotNull();

            Assert.True(result);

        }

        [Theory]
        [InlineData("DnDMan13")]
        [InlineData("DnD_Man13")]
        [InlineData("DnD.Man13")]
        [InlineData("DnD_Man.13")]
        public void IsValidUserName_Valid(string userNameTest)
        {
            
            Logic.Objects.Client client = new Client
            {
                UserName = userNameTest,
                Email = "DnDMan13@yahoo.com",
                PasswordHash = "Password1234"
            };

            var result = client.IsValidUserName();

            Assert.True(result);

        }

        [Theory]
        [InlineData("_DnDMan13")]
        [InlineData(".DnDMan13")]
        [InlineData("DnDMan13.")]
        [InlineData("DnDMan13_")]
        [InlineData("DnD__Man13")]
        [InlineData("DnD_.Man13")]
        [InlineData("DnD..Man13")]
        [InlineData("DnD$Man13")]
        [InlineData("DnD@Man13")]
        public void IsValidUserName_Invalid(string userNameTest)
        {
            Logic.Objects.Client client = new Client
            {
                UserName = userNameTest,
                Email = "DnDMan13@yahoo.com",
                PasswordHash = "Password1234"
            };

            var result = client.IsValidUserName();

            Assert.True(!result);

        }

        [Fact]
        public void IsValidEmail_Valid()
        {

            Logic.Objects.Client client = new Client
            {
                UserName = "DnDMan13",
                Email = "DnDMan13@yahoo.com",
                PasswordHash = "Password1234"
            };

            var result = client.IsValidEmail();

            Assert.True(result);

        }

        [Theory]
        [InlineData("@herweare.com")]
        [InlineData("plainaddress")]
        [InlineData("#@%^%#$@#$@#.com")] 
        [InlineData("@domain.com")] 
        [InlineData("Joe Smith <email @domain.com>")]
        [InlineData("email.domain.com")]
        [InlineData("email @domain@domain.com")]
        [InlineData(".email @domain.com")] 
        [InlineData("email.@domain.com")] 
        [InlineData("email..email @domain.com")]
        [InlineData("あいうえお@domain.com")] 
        [InlineData("email@domain.com (Joe Smith)")]
        [InlineData("email @domain")]    
        [InlineData("email@-domain.com")]
        [InlineData("email@domain..com")]
        public void IsValidEmail_Invalid(string emailTest)
        {
            Logic.Objects.Client client = new Client
            {
                UserName = "DnDMan13",
                Email = emailTest,
                PasswordHash = "Password1234"
            };

            var result = client.IsValidEmail();

            Assert.True(!result);

        }

        [Fact]
        public void IsValidPasswordHash_Valid()
        {
            Logic.Objects.Client client = new Client
            {
                UserName = "DnDMan13",
                Email = "DnDMan13@yahoo.com",
                PasswordHash = "Password1234"
            };

            var result = client.IsValidPasswordHash();

            Assert.True(result);

        }

        [Theory]
        [InlineData("Pass")]
        [InlineData("Password...")]
        public void IsValidPasswordHash_Invalid(string password)
        {
            Logic.Objects.Client client = new Client
            {
                UserName = "DnDMan13",
                Email = "DnDMan13@yahoo.com",
                PasswordHash = password
            };

            var result = client.IsValidPasswordHash();

            Assert.True(!result);

        }




    }
}

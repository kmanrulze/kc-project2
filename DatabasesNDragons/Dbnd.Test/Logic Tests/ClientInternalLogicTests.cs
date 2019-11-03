using System;
using Xunit;
using Dbnd.Logic.Objects;

namespace Dbnd.Test
{
    public class ClientInternalLogicTests
    {

        [Fact]
        public void ClientControllerGeneratesGUID()
        {
            string userName = "Novum_Usor";
            string email = "Novum_Usor11@email.com";

            Client client = new Client(userName, email);

            Assert.True(Guid.TryParse(client.ClientID.ToString(), out var successGuid));
        }

        [Fact]
        public void RequiredFieldsNotNull_CheckNull()
        {
            Logic.Objects.Client client = new Client();

            var result = client.RequiredFieldsNotNull();

            Assert.False(result);

        }

        [Fact]
        public void RequiredFieldsNotNull_CheckNotNull()
        {
            Logic.Objects.Client client = new Client
            {
                UserName = "DnDMan13",
                Email = "DnDMan13@yahoo.com"
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
                Email = "DnDMan13@yahoo.com"
            };

            var result = client.IsValidUserName();

            Assert.False(result);

        }

        [Fact]
        public void IsValidEmail_Valid()
        {

            Logic.Objects.Client client = new Client
            {
                UserName = "DnDMan13",
                Email = "DnDMan13@yahoo.com",
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
        [InlineData("  ")]
        public void IsValidEmail_Invalid(string emailTest)
        {
            Logic.Objects.Client client = new Client
            {
                UserName = "DnDMan13",
                Email = emailTest,
            };

            var result = client.IsValidEmail();

            Assert.False(result);

        }
        [Theory]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaX@email.com")]
        public void IsValidEmail_EvilRegex(string emailTest)
        {
            Logic.Objects.Client client = new Client
            {
                UserName = "DnDMan13",
                Email = emailTest,
            };

            var result = client.IsValidEmail();

            Assert.False(result);

        }
    }
}

using System;
using Xunit;
using Dbnd.Logic.Objects;

namespace Dbnd.Test
{
    public class ClientTests
    {
        [Fact]
        public void ChangeClientName()
        {
            Client newClient = new Client
            {
                UserName = "test"
            };
            newClient.UserName = "changed";
            Assert.Equal("changed", newClient.UserName);
        }
        [Fact]
        public void ChangeClientEmail()
        {
            Client newClient = new Client
            {
                Email = "test@test.com"
            };
            newClient.UserName = "changed@changed.com";
            Assert.Equal("changed@changed.com", newClient.Email);
        }
    }
}

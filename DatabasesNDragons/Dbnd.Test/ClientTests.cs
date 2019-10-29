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
            newClient.Email = "changed@changed.com";
            Assert.Equal("changed@changed.com", newClient.Email);
        }
        [Fact]
        public void TestGUID()
        {
            Client testClinet = new Client
            {
                ClientID = Guid.NewGuid()
            };
            Guid guidResult;
            Assert.True(Guid.TryParse(testClinet.ClientID.ToString(), out guidResult));
        }
    }
}

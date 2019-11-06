using Microsoft.EntityFrameworkCore;
using Xunit;

using Dbnd.Data.Entities;
using Dbnd.Data.Repository;

namespace Dbnd.Test.Repository_Tests
{
    public class DbndContextTests
    {
        [Fact]
        public void DbnDContextTest()
        {
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd")
            .Options;

            using (var context = new DbndContext(options))
            {
                context.Client.Add(new Client { UserName = "Aramand", Email = "Aramand@gmail.com" });
                context.Client.Add(new Client { UserName = "Lestat", Email = "Lestat@gmail.com" });
                context.Client.Add(new Client { UserName = "Claudia", Email = "Claudia@gmail.com" });
                context.SaveChanges();
            }

            using (var context = new DbndContext(options))
            {
                Repository repository = new Repository(context);
                var clientbyEmail = repository.GetClientByEmailAsync("Aramand@gmail.com").Result;
                var clientbyID = repository.GetClientByIDAsync(clientbyEmail.ClientID).Result;

                Assert.Equal("Aramand", clientbyEmail.UserName);
                Assert.Equal("Aramand", clientbyID.UserName);
            }
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using Dbnd.Data.Entities;
using Dbnd.Data.Repository;
using System;

namespace Dbnd.Test.Repository_Tests
{
    public class RepositoryEFCoreTests
    {
        [Theory]
        [InlineData("Aramand@gmail.com")]
        public void GetClientWithValidEmail(string email)
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
                var clientbyEmail = repository.GetClientByEmailAsync(email).Result;
                var clientbyID = repository.GetClientByIDAsync(clientbyEmail.ClientID).Result;

                Assert.Equal("Aramand", clientbyEmail.UserName);
                Assert.Equal("Aramand", clientbyID.UserName);
            }
        }

        [Theory]
        [InlineData("Lewis@gmail.com")]
        public void GetClientWithInvalidEmail(string email)
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

                Assert.Throws<AggregateException>( () => repository.GetClientByEmailAsync(email).Result );
            }
        }

        [Fact]
        public void GetAllClientsSuccess()
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
                var clients = repository.GetClientsAsync().Result;
                var clientCount = clients.Count();

                Assert.Equal(3, clientCount);
            }
        }

        [Fact]
        public void GetAllCharactersSuccess()
        {
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd")
            .Options;

            using (var context = new DbndContext(options))
            {
                context.Character.Add(new Character { FirstName = "Rowan", LastName = "Garrowsson", ClientID = Guid.NewGuid() });
                context.Character.Add(new Character { FirstName = "Brom", LastName = "Irons", ClientID = Guid.NewGuid() });
                context.Character.Add(new Character { FirstName = "Orik", LastName = "Slayersfelt", ClientID = Guid.NewGuid() });
                context.SaveChanges();
            }

            using (var context = new DbndContext(options))
            {
                Repository repository = new Repository(context);
                var characters = repository.GetCharactersAsync().Result;
                var charactersCount = characters.Count();

                Assert.Equal(3, charactersCount);
            }
        }

    }
}

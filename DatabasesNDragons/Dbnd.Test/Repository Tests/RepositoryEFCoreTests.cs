using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using Dbnd.Data.Entities;
using Dbnd.Data.Repository;
using System;
using System.Threading.Tasks;

namespace Dbnd.Test.Repository_Tests
{
    public class RepositoryEFCoreTests
    {

        [Theory]
        [InlineData("Aramand@gmail.com")]
        public void GetClientWithValidEmail(string email)
        {
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd1")
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
            .UseInMemoryDatabase(databaseName: "Dbnd2")
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

        /* [Fact]
        public void GetAllClientsSuccess()
        {
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd3")
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
        } */ 
        
        /* [Fact]
        public async Task CreateClientsSuccess()
        {
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd4")
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
                await repository.CreateClientAsync("Wonderstam", "newkidsontheblock@gmail.com");
                var clients = repository.GetClientsAsync().Result;
                var clientCount = clients.Count();
                Assert.Equal(4, clientCount);
            }
        }*/

        [Fact]
        public async Task UpdateClientsByIDSuccess()
        {
            var targetID = Guid.NewGuid();

            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd5")
            .Options;

            using (var context = new DbndContext(options))
            {
                context.Client.Add(new Client { UserName = "Aramand", Email = "Aramand@gmail.com" });
                context.Client.Add(new Client { UserName = "Lestat", Email = "Lestat@gmail.com" });
                context.Client.Add(new Client() { UserName = "Claudia", Email = "Claudia@gmail.com", ClientID = targetID });
                context.SaveChanges();
            }

            using (var context = new DbndContext(options))
            {
                Repository repository = new Repository(context);
                await repository.UpdateClientByIDAsync(targetID, new Logic.Objects.Client() { UserName = "Abagail" });
                var client = repository.GetClientByIDAsync(targetID).Result;
                Assert.Equal("Abagail", client.UserName);
            }
        }

        [Fact]
        public async Task DeleteClientsByIDSuccess()
        {
            var targetID = Guid.NewGuid();

            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd6")
            .Options;

            using (var context = new DbndContext(options))
            {
                context.Client.Add(new Client { UserName = "Aramand", Email = "Aramand@gmail.com" });
                context.Client.Add(new Client { UserName = "Lestat", Email = "Lestat@gmail.com" });
                context.Client.Add(new Client() { UserName = "Claudia", Email = "Claudia@gmail.com", ClientID = targetID });
                context.SaveChanges();
            }

            using (var context = new DbndContext(options))
            {
                Repository repository = new Repository(context);
                await repository.DeleteClientByIDAsync(targetID);
                var clients = await context.Client.ToListAsync();
                var clientCount = clients.Count();
                Assert.Equal(2, clientCount);
            }
        }

        /* [Fact]
        public void GetGamesSuccess()
        {

            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd11")
            .Options;

            using (var context = new DbndContext(options))
            {
                context.Game.Add(new Game { GameID = Guid.NewGuid(), ClientID = Guid.NewGuid(), GameName = "DragonBreath" });
                context.Game.Add(new Game { GameID = Guid.NewGuid(), ClientID = Guid.NewGuid(), GameName = "LionWhisper" });
                context.Game.Add(new Game { GameID = Guid.NewGuid(), ClientID = Guid.NewGuid(), GameName = "HorseTooth" });
                context.SaveChanges();
            }

            using (var context = new DbndContext(options))
            {
                Repository repository = new Repository(context);
                var games = repository.GetGamesAsync().Result;
                var gamesCount = games.Count();

                Assert.Equal(3, gamesCount);
            }
        }*/

        [Fact]
        public void GetGameByGameIDAsyncSuccess()
        {
            var targetID = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd12")
            .Options;

            using (var context = new DbndContext(options))
            {
                context.Game.Add(new Game { GameID = targetID, ClientID = Guid.NewGuid(), GameName = "DragonBreath" });
                context.Game.Add(new Game { GameID = Guid.NewGuid(), ClientID = Guid.NewGuid(), GameName = "LionWhisper" });
                context.Game.Add(new Game { GameID = Guid.NewGuid(), ClientID = Guid.NewGuid(), GameName = "HorseTooth" });
                context.SaveChanges();
            }

            using (var context = new DbndContext(options))
            {
                Repository repository = new Repository(context);
                var game = repository.GetGameByIDAsync(targetID).Result;
                Assert.Equal(targetID, game.GameID);
            }
        }

        [Fact]
        public void GetGamesByClientIDAsyncSuccess()
        {
            var targetID = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd13")
            .Options;

            using (var context = new DbndContext(options))
            {
                context.Game.Add(new Game { GameID = Guid.NewGuid(), ClientID = targetID, GameName = "DragonBreath" });
                context.Game.Add(new Game { GameID = Guid.NewGuid(), ClientID = targetID, GameName = "LionWhisper" });
                context.Game.Add(new Game { GameID = Guid.NewGuid(), ClientID = Guid.NewGuid(), GameName = "HorseTooth" });
                context.SaveChanges();
            }

            using (var context = new DbndContext(options))
            {
                Repository repository = new Repository(context);
                var games = repository.GetGamesByClientIDAsync(targetID).Result;
                var count = games.Count();
                Assert.Equal(2, count);
            }
        }
        [Fact]
        public async Task CreateGameAsyncSuccess()
        {
            var targetID = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd14")
            .Options;

            using (var context = new DbndContext(options))
            {
                context.Game.Add(new Game { GameID = Guid.NewGuid(), ClientID = targetID, GameName = "DragonBreath" });
                context.Game.Add(new Game { GameID = Guid.NewGuid(), ClientID = targetID, GameName = "LionWhisper" });
                context.Game.Add(new Game { GameID = Guid.NewGuid(), ClientID = Guid.NewGuid(), GameName = "HorseTooth" });
                context.SaveChanges();
            }

            using (var context = new DbndContext(options))
            {
                Repository repository = new Repository(context);
                await repository.CreateGameAsync(targetID, "BirdFeatherFall");
                var games = context.Game.Where(x => x.ClientID == targetID);
                var count = games.Count();
                Assert.Equal(3, count);
            }
        }
        [Fact]
        public async Task UpdateGameAsyncSuccess()
        {
            var targetID = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd15")
            .Options;

            using (var context = new DbndContext(options))
            {
                context.Game.Add(new Game { GameID = targetID, ClientID = Guid.NewGuid(), GameName = "DragonBreath" });
                context.Game.Add(new Game { GameID = Guid.NewGuid(), ClientID = Guid.NewGuid(), GameName = "LionWhisper" });
                context.Game.Add(new Game { GameID = Guid.NewGuid(), ClientID = Guid.NewGuid(), GameName = "HorseTooth" });
                context.SaveChanges();
            }

            using (var context = new DbndContext(options))
            {
                Repository repository = new Repository(context);
                await repository.UpdateGameAsync(targetID, new Logic.Objects.Game() { GameName = "HippoEars" });
                var game = context.Game.FirstAsync(x => x.GameID == targetID).Result;
                var targetName = game.GameName;
                Assert.Equal("HippoEars", targetName);
            }
        }
        [Fact]
        public async Task DeleteGameAsyncSuccess()
        {
            var targetID = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd16")
            .Options;

            using (var context = new DbndContext(options))
            {
                context.Game.Add(new Game { GameID = targetID, ClientID = Guid.NewGuid(), GameName = "DragonBreath" });
                context.Game.Add(new Game { GameID = Guid.NewGuid(), ClientID = Guid.NewGuid(), GameName = "LionWhisper" });
                context.Game.Add(new Game { GameID = Guid.NewGuid(), ClientID = Guid.NewGuid(), GameName = "HorseTooth" });
                context.SaveChanges();
            }

            using (var context = new DbndContext(options))
            {
                Repository repository = new Repository(context);
                await repository.DeleteGameByIDAsync(targetID);
                var games = context.Game;
                var count = games.Count();
                Assert.Equal(2, count);
            }
        }

        /* [Fact]
        public void GetAllCharactersSuccess()
        {
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd17")
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
        } */

        /* [Fact]
        public void GetCharacterByCharacterIDAsync()
        {
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd18")
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
        } */

        /* [Fact]
        public async Task CreateCharacterAsyncSuccessful()
        {
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd19")
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
                await repository.CreateCharacterAsync(Guid.NewGuid(), "Gabriella", "Ricenbomn");
                var characters = repository.GetCharactersAsync().Result;
                var charactersCount = characters.Count();

                Assert.Equal(4, charactersCount);
            }
        } */

        [Fact]
        public async Task UpdateCharacterAsyncSuccessful()
        {
            var targetID = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd20")
            .Options;

            using (var context = new DbndContext(options))
            {
                context.Character.Add(new Character { CharacterID = targetID, FirstName = "Rowan", LastName = "Garrowsson", ClientID = Guid.NewGuid() });
                context.Character.Add(new Character { FirstName = "Brom", LastName = "Irons", ClientID = Guid.NewGuid() });
                context.Character.Add(new Character { FirstName = "Orik", LastName = "Slayersfelt", ClientID = Guid.NewGuid() });
                context.SaveChanges();
            }

            using (var context = new DbndContext(options))
            {
                Repository repository = new Repository(context);
                await repository.UpdateCharacterByIDAsync(targetID, new Logic.Objects.Character() { FirstName = "Robin" });
                var character = context.Character.FirstAsync(x => x.CharacterID == targetID).Result;
                var characterName = character.FirstName;

                Assert.Equal("Robin", characterName);
            }
        }

        [Fact]
        public async Task DeleteCharacterAsyncSuccessful()
        {
            var targetID = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd21")
            .Options;

            using (var context = new DbndContext(options))
            {
                context.Character.Add(new Character { CharacterID = targetID, FirstName = "Rowan", LastName = "Garrowsson", ClientID = Guid.NewGuid() });
                context.Character.Add(new Character { FirstName = "Brom", LastName = "Irons", ClientID = Guid.NewGuid() });
                context.Character.Add(new Character { FirstName = "Orik", LastName = "Slayersfelt", ClientID = Guid.NewGuid() });
                context.SaveChanges();
            }

            using (var context = new DbndContext(options))
            {
                Repository repository = new Repository(context);
                await repository.DeleteCharacterByIDAsync(targetID);
                var characters = context.Character;
                var charactersCount = characters.Count();

                Assert.Equal(2, charactersCount);
            }
        }

        /* [Fact]
        public async Task AddEntryToCharacterGameXRefSuccess()
        {
            var targetID = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd22")
            .Options;

            using (var context = new DbndContext(options))
            {
                context.CharacterGameXRef.Add(new CharacterGameXRef { GameID = Guid.NewGuid(), CharacterID = Guid.NewGuid() });
                context.CharacterGameXRef.Add(new CharacterGameXRef { GameID = Guid.NewGuid(), CharacterID = Guid.NewGuid() });
                context.CharacterGameXRef.Add(new CharacterGameXRef { GameID = Guid.NewGuid(), CharacterID = Guid.NewGuid() });
                context.CharacterGameXRef.Add(new CharacterGameXRef { GameID = Guid.NewGuid(), CharacterID = Guid.NewGuid() });

                context.SaveChanges();
            }

            using (var context = new DbndContext(options))
            {
                Repository repository = new Repository(context);
                await repository.AddEntryToCharacterGameXRef(Guid.NewGuid(), Guid.NewGuid());
                var xref = context.CharacterGameXRef;
                var xrefCount = xref.Count();
                Assert.Equal(5, xrefCount);
            }
        } 

        [Fact]
        public async Task RemoveEntryToCharacterGameXRefSuccess()
        {
            var targetGameID = Guid.NewGuid();
            var targetCharID = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd23")
            .Options;

            using (var context = new DbndContext(options))
            {
                context.CharacterGameXRef.Add(new CharacterGameXRef { GameID = targetGameID, CharacterID = targetCharID });
                context.CharacterGameXRef.Add(new CharacterGameXRef { GameID = Guid.NewGuid(), CharacterID = Guid.NewGuid() });
                context.CharacterGameXRef.Add(new CharacterGameXRef { GameID = Guid.NewGuid(), CharacterID = Guid.NewGuid() });
                context.CharacterGameXRef.Add(new CharacterGameXRef { GameID = Guid.NewGuid(), CharacterID = Guid.NewGuid() });

                context.SaveChanges();
            }

            using (var context = new DbndContext(options))
            {
                Repository repository = new Repository(context);
                await repository.RemoveEntryToCharacterGameXRefAsync(targetGameID, targetCharID);
                var xref = context.CharacterGameXRef;
                var xrefCount = xref.Count();
                Assert.Equal(3, xrefCount);
            }
        }

        [Fact]
        public async Task GetEntryFromCharacterGameXRefByIDsSuccess()
        {
            var targetGameID = Guid.NewGuid();
            var targetCharID = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<DbndContext>()
            .UseInMemoryDatabase(databaseName: "Dbnd24")
            .Options;

            using (var context = new DbndContext(options))
            {
                context.CharacterGameXRef.Add(new CharacterGameXRef { GameID = targetGameID, CharacterID = targetCharID });
                context.CharacterGameXRef.Add(new CharacterGameXRef { GameID = Guid.NewGuid(), CharacterID = Guid.NewGuid() });
                context.CharacterGameXRef.Add(new CharacterGameXRef { GameID = Guid.NewGuid(), CharacterID = Guid.NewGuid() });
                context.CharacterGameXRef.Add(new CharacterGameXRef { GameID = Guid.NewGuid(), CharacterID = Guid.NewGuid() });

                context.SaveChanges();
            }

            using (var context = new DbndContext(options))
            {
                Repository repository = new Repository(context);
                await repository.GetEntryFromCharacterGameXRefByIDs(targetGameID, targetCharID);
                var xref = context.CharacterGameXRef.FirstAsync(x => x.CharacterID == targetCharID && x.GameID == targetGameID).Result;

                Assert.Equal(targetGameID, xref.GameID);
                Assert.Equal(targetCharID, xref.CharacterID);
            }
        } */

    }
}

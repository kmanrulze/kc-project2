using System;
using System.Collections.Generic;
using Dbnd.Logic.Interfaces;
using Dbnd.Data.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dbnd.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly DbndContext _context;

        public Repository(DbndContext dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #region Character
        public async Task<Logic.Objects.Character> GetCharacterByIDAsync(Guid characterID)
        {
            try
            {
                return Mapper.MapCharacter(await _context.Character.FirstOrDefaultAsync(pc => pc.CharacterID == characterID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within GetCharacterByCharacterIDAsync: " + e.Message);
                return null;
            }
        }
        public async Task<IEnumerable<Logic.Objects.Character>> GetClientCharactersAsync(Guid clientId)
        {
            try
            {
                return _context.Character.Select(Mapper.MapCharacter).Where(c => c.ClientID == clientId).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within GetClientCharactersAsync: " + e.Message);
                return null;
            }
        }
        public async Task<Logic.Objects.Character> CreateCharacterAsync(Guid clientID, string firstName, string lastName)
        {
            try
            {
                Logic.Objects.Character character = new Logic.Objects.Character(clientID, firstName, lastName);
                _context.Character.Add(Mapper.MapCharacter(character));
                await _context.SaveChangesAsync();
                return character;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within CreateCharacterAsync: " + e.Message);
                return null;
            }
        }
        public async Task<bool> UpdateCharacterByIDAsync(Guid targetCharacterID, Logic.Objects.Character changedCharacter)
        {
            try
            {
                var targetCharacter = await _context.Character.FirstOrDefaultAsync(g => g.CharacterID == targetCharacterID);

                if (targetCharacter == null)
                    return false;

                targetCharacter.FirstName = changedCharacter.FirstName;
                targetCharacter.LastName = changedCharacter.LastName;
                targetCharacter.ClientID = changedCharacter.ClientID;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within UpdateCharacterByIDAsync: " + e.Message);
                return false;
            }
        }
        public async Task<bool> DeleteCharacterByIDAsync(Guid characterID)
        {
            try
            {
                Character contextCharacter = await _context.Character.FirstOrDefaultAsync(c => c.CharacterID == characterID);

                if (contextCharacter == null)
                    return false;

                _context.Character.Remove(contextCharacter);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within DeleteCharacterByIDAsync: " + e.Message);
                return false;
            }
        }
        #endregion

        #region Client
        public async Task<Logic.Objects.Client> GetClientByIDAsync(Guid clientID)
        {
            try
            {
                return Mapper.MapClient(await _context.Client.Include(c => c.Characters).Include(c => c.Games).FirstOrDefaultAsync(c => c.ClientID == clientID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within GetClientByIDAsync: " + e.Message);
                return null;
            }
        }
        public async Task<Logic.Objects.Client> GetClientByEmailAsync(string email)
        {
            try
            {
                return Mapper.MapClient(await _context.Client.FirstOrDefaultAsync(c => c.Email == email));
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within GetClientByEmailAsync: " + e.Message);
                return null;
            }
        }
        public async Task<Logic.Objects.Client> CreateClientAsync(string userName, string email)
        {
            try
            {
                Logic.Objects.Client client = new Logic.Objects.Client(userName, email);
                _context.Client.Add(Mapper.MapClient(client));
                await _context.SaveChangesAsync();
                return client;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within CreateClientAsync: " + e.Message);
                return null;
            }

        }
        public async Task<bool> UpdateClientByIDAsync(Guid targetClientID, Logic.Objects.Client changedClient)
        {
            try
            {
                var targetClient = await _context.Client.FirstOrDefaultAsync(g => g.ClientID == targetClientID);

                if (targetClient == null)
                    return false;

                targetClient.UserName = changedClient.UserName;
                targetClient.Email = changedClient.Email;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within UpdateClientByIDAsync: " + e.Message);
                return false;
            }
        }
        public async Task<bool> DeleteClientByIDAsync(Guid clientID)
        {
            try
            {
                Client contextClient = await _context.Client.FirstOrDefaultAsync(c => c.ClientID == clientID);

                if (contextClient == null)
                    return false;

                _context.Client.Remove(contextClient);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within DeleteClientByIDAsync: " + e.Message);
                return false;
            }
        }
        #endregion

        #region Game
        public async Task<Logic.Objects.Game> GetGameByIDAsync(Guid gameID)
        {
            try
            {
                return Mapper.MapGame(await _context.Game.FirstAsync(g => g.GameID == gameID));
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong within GetGameByGameIDAsync: " + e.Message);
                return null;
            }
        }

        public async Task<List<Logic.Objects.Game>> GetGamesByClientIDAsync(Guid clientID)
        {
            try
            {
                var entityGameList = _context.Game.Where(x => x.ClientID == clientID || x.Characters.FirstOrDefault(ch => ch.ClientID == clientID) != null);
                return entityGameList.Select(Mapper.MapGame).ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong within GetGamesByClientIDAsync: " + e.Message);
                return null;
            }
        }

        public async Task<Logic.Objects.Game> CreateGameAsync(Guid clientID, string gameName)
        {
            try
            {
                Logic.Objects.Game game = new Logic.Objects.Game(clientID, gameName);
                _context.Game.Add(Mapper.MapGame(game));
                await _context.SaveChangesAsync();
                return game;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within CreateGameAsync: " + e.Message);
                return null;
            }
        }

        public async Task<bool> UpdateGameAsync(Guid targetGameID, Logic.Objects.Game changedGame)
        {
            try
            {
                var targetGame = await _context.Game.FirstOrDefaultAsync(g => g.GameID == targetGameID);

                if (targetGame == null)
                    return false;

                targetGame.GameName = changedGame.GameName;
                targetGame.ClientID = changedGame.ClientID;
                targetGame.Characters = changedGame.Characters.Select(Mapper.MapCharacter).ToList();
                targetGame.Overviews = changedGame.Overviews.Select(Mapper.MapOverview).ToList();
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within UpdateGameAsync: " + e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteGameByIDAsync(Guid gameID)
        {
            try 
            {
                _context.Remove(await _context.Game.FirstAsync(g => g.GameID == gameID));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within DeleteGameAsync: " + e.Message);
                return false;
            }
        }
        
        #endregion

        #region Overview
        // Taking out the type stuff until its fleshed out more
        public async Task<Logic.Objects.Overview> CreateOverviewAsync(Guid gameID, string name, string content)
        {
            try
            {
                Logic.Objects.Overview overview = new Logic.Objects.Overview(gameID, name, content);
                _context.Overview.Add(Mapper.MapOverview(overview));
                await _context.SaveChangesAsync();
                return overview;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within CreateOverviewAsync: " + e.Message);
                return null;
            }
        }
        public async Task<Logic.Objects.Overview> GetOverviewByIDAsync(Guid overviewID)
        {
            try
            {
                return Mapper.MapOverview(await _context.Overview.FirstAsync(o => o.OverviewID == overviewID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within GetOverviewByIDAsync: " + e.Message);
                return null;
            }
        }
        public async Task<bool> UpdateOverviewByIDAsync(Guid targetOverviewID, Logic.Objects.Overview changedOverview)
        {
            try
            {
                Entities.Overview targetOverview = await _context.Overview.FirstOrDefaultAsync(o => o.OverviewID == targetOverviewID);
                targetOverview.Name = changedOverview.Name;
                targetOverview.Content = changedOverview.Content;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within UpdateOverviewByIDAsync: " + e.Message);
                return false;
            }
        }
        public async Task<bool> DeleteOverviewByIDAsync(Guid overviewID)
        {
            try
            {
                Overview contextOverview = await _context.Overview.FirstOrDefaultAsync(o => o.OverviewID == overviewID);

                if (contextOverview != null)
                    return false;

                _context.Overview.Remove(contextOverview);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within CreateOverviewAsync: " + e.Message);
                return true;
            }
        }
        #endregion

        #region Deprecated
        /* These are on life support. We acheive this behavior by getting a Game and, for example, adding a Character to its Characters property
          * 
         public async Task<CharacterGameXRef> GetEntryFromCharacterGameXRefByIDs(Guid gameID, Guid characterID)
         {
             try
             {
                 return await _context.CharacterGameXRef.FirstAsync(x => x.GameID == gameID && x.CharacterID == characterID);
             }
             catch (Exception e)
             {
                 Console.WriteLine("Something went wrong within GetEntryFromCharacterGameXRefByIDs: " + e.Message);
                 return null;
             }
         }

         public async Task AddEntryToCharacterGameXRef(Guid gameID, Guid characterID)
         {
             try
             {
                 var entryToAdd = new CharacterGameXRef()
                 {
                     GameID = gameID,
                     CharacterID = characterID
                 };
                 await _context.CharacterGameXRef.AddAsync(entryToAdd);
                 await _context.SaveChangesAsync();
             }
             catch (Exception e)
             {
                 Console.WriteLine("Something went wrong within AddEntryToCharacterGameXRef: " + e.Message);
             }
         }

         public async Task RemoveEntryToCharacterGameXRefAsync(Guid gameID, Guid characterID)
         {
             try
             {
                 var entryToRemove = GetEntryFromCharacterGameXRefByIDs(gameID, characterID).Result;
                 _context.CharacterGameXRef.Remove(entryToRemove);
                 await _context.SaveChangesAsync();
             }
             catch (Exception e)
             {
                 Console.WriteLine("Something went wrong within RemoveEntryToCharacterGameXRefAsync: " + e.Message);
             }
         }*/
        #endregion
    }
}

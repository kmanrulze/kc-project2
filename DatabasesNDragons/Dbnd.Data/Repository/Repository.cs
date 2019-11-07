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
        public async Task<IEnumerable<Logic.Objects.Character>> GetCharactersAsync()
        {
            var entityCharList = await _context.Character.ToListAsync();
            return entityCharList.Select(Mapper.MapCharacter);
        }

        public async Task<Logic.Objects.Character> GetCharacterByCharacterIDAsync(Guid characterID)
        {
            try
            {
                Logic.Objects.Character LogicCharacter = Mapper.MapCharacter(await _context.Character.FirstAsync(pc => pc.CharacterID == characterID));
                if (LogicCharacter == null)
                {
                    throw new ArgumentNullException("LogicCharacter null");
                }
                else
                {
                    return LogicCharacter;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within GetCharacterByCharacterIDAsync: " + e.Message);
                return null;
            }
        }

        public async Task CreateCharacterAsync(Guid clientID, string firstName, string lastName)
        {
            try
            {
                _context.Character.Add(Mapper.MapCharacter(new Logic.Objects.Character(clientID, firstName, lastName)));
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within CreateCharacterAsync: " + e.Message);
            }
        }
        public async Task UpdateCharacterByIDAsync(Guid targetCharacterID, Logic.Objects.Character changedCharacter)
        {
            try
            {
                var targetCharacter = await _context.Character.FirstAsync(g => g.CharacterID == targetCharacterID);
                var madeChange = false;

                if (!String.IsNullOrEmpty(changedCharacter.FirstName) && targetCharacter.FirstName != changedCharacter.FirstName)
                {
                    targetCharacter.FirstName = changedCharacter.FirstName;
                    madeChange = true;
                }
                if (!String.IsNullOrEmpty(changedCharacter.LastName) && targetCharacter.LastName != changedCharacter.LastName)
                {
                    targetCharacter.LastName = changedCharacter.LastName;
                    madeChange = true;
                }

                if (madeChange) { await _context.SaveChangesAsync(); };
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within UpdateCharacterByIDAsync: " + e.Message);
            }
        }

        public async Task DeleteCharacterByIDAsync(Guid characterID)
        {
            try
            {
                Character ContextCharacter = await _context.Character.FirstAsync(c => c.CharacterID == characterID);
                _context.Character.Remove(ContextCharacter);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within DeleteCharacterByIDAsync: " + e.Message);
            }
        }
        #endregion

        #region Client
        public async Task<Logic.Objects.Client> GetClientByIDAsync(Guid clientID)
        {
            try
            {
                Logic.Objects.Client LogicClient = Mapper.MapClient(await _context.Client.FirstAsync(c => c.ClientID == clientID));
                if (LogicClient == null)
                {
                    throw new ArgumentNullException("LogicClient");
                }
                else
                {
                    return LogicClient;
                }

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
                Logic.Objects.Client LogicClient = Mapper.MapClient(await _context.Client.FirstAsync(c => c.Email == email));
                return LogicClient;
            }
            catch
            {
                throw new Exception($"did not get client successfully: {email}");
            }
        }

        public async Task CreateClientAsync(string userName, string email)
        {
            try
            {
                _context.Client.Add(Mapper.MapClient(new Logic.Objects.Client(userName, email)));
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within CreateClientAsync: " + e.Message);
            }

        }

        public async Task UpdateClientByIDAsync(Guid targetClientID, Logic.Objects.Client changedClient)
        {
            try
            {
                var targetClient = await _context.Client.FirstAsync(g => g.ClientID == targetClientID);
                var madeChange = false;

                if (!String.IsNullOrEmpty(changedClient.UserName) && targetClient.UserName != changedClient.UserName)
                {
                    targetClient.UserName = changedClient.UserName;
                    madeChange = true;
                }
                if (!String.IsNullOrEmpty(changedClient.Email) && targetClient.Email != changedClient.Email)
                {
                    targetClient.Email = changedClient.Email;
                    madeChange = true;
                }

                if (madeChange) { await _context.SaveChangesAsync(); };
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within UpdateClientByIDAsync: " + e.Message);
            }
        }

        public async Task DeleteClientByIDAsync(Guid clientID)
        {
            try
            {
                Client ContextClient = await _context.Client.FirstAsync(c => c.ClientID == clientID);
                _context.Client.Remove(ContextClient);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within DeleteClientByIDAsync: " + e.Message);
            }
        }
        #endregion

        #region Game
        public async Task<IEnumerable<Logic.Objects.Game>> GetGamesAsync()
        {
            try
            {
                var entityGameList = await _context.Game.ToListAsync();
                return entityGameList.Select(Mapper.MapGame);
            } 
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong within GetGamesAsync: " + e.Message);
                return null;
            }
        }

        public async Task<Logic.Objects.Game> GetGameByIDAsync(Guid gameID)
        {
            try
            {
                Logic.Objects.Game LogicGame = Mapper.MapGame(await _context.Game.FirstAsync(g => g.GameID == gameID));
                if (LogicGame == null)
                {
                    throw new ArgumentNullException("LogicGame");
                }
                else
                {
                    return LogicGame;
                }
                
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
                var entityGameList = await _context.Game.Where(x => x.ClientID == clientID || x.Characters.FirstOrDefault(ch => ch.ClientID == clientID) != null).ToListAsync();
                return entityGameList.Select(Mapper.MapGame).ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong within GetGamesByClientIDAsync: " + e.Message);
                return null;
            }
        }

        public async Task CreateGameAsync(Guid clientID, string gameName)
        {
            try
            {
                _context.Game.Add(Mapper.MapGame(new Logic.Objects.Game(clientID, gameName)));
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within CreateGameAsync: " + e.Message);
            }
        }

        public async Task UpdateGameAsync(Guid targetGameID, Logic.Objects.Game changedGame)
        {
            try
            {
                var targetGame = await _context.Game.FirstAsync(g => g.GameID == targetGameID);

                if (targetGame.GameName != changedGame.GameName) 
                {
                    targetGame.GameName = changedGame.GameName;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within UpdateGameAsync: " + e.Message);
            }
        }

        public async Task DeleteGameByIDAsync(Guid gameID)
        {
            try 
            {
                _context.Remove(await _context.Game.FirstAsync(g => g.GameID == gameID));
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within DeleteGameAsync: " + e.Message);
            }
        }
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
        }
        #endregion

        #region Overview
        public async Task CreateOverviewAsync(Guid gameID, string name, string content)
        {

        }
        public async Task<Logic.Objects.Overview> GetOverviewByIDAsync(Guid overviewID)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateOverviewByIDAsync(Guid targetCharacterID, Logic.Objects.Overview changedOverview)
        {

        }
        public async Task DeleteOverviewByIDAsync(Guid characterID)
        {

        }
        #endregion

        #region Deprecated
        public async Task<IEnumerable<Logic.Objects.Client>> GetClientsAsync()
        {
            var entityClientList = await _context.Client.ToListAsync();
            return entityClientList.Select(Mapper.MapClient);
        }
        public async Task<List<Logic.Objects.Character>> GetAllCharactersInGameByGameIDAsync(Guid gameID)
        {
            try
            {
                var listCharacterIds = await _context.CharacterGameXRef.Where(x => x.GameID == gameID).ToListAsync();
                var listCharacters = new List<Logic.Objects.Character>();
                foreach (var entry in listCharacterIds)
                {
                    listCharacters.Add(GetCharacterByCharacterIDAsync(entry.CharacterID).Result);
                }

                return listCharacters;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong within GetAllCharactersInGameByGameIDAsync: " + e.Message);
                return null;
            }

        }

        #endregion
    }
}

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

        public async Task<IEnumerable<Logic.Objects.Character>> GetCharactersAsync()
        {
            var entityCharList = await _context.Character.ToListAsync();
            return entityCharList.Select(Mapper.MapCharacter);
        }

        public async Task<Logic.Objects.Character> GetCharacterByCharacterIDAsync(Guid CharacterID)
        {
            try
            {
                Logic.Objects.Character LogicCharacter = Mapper.MapCharacter(await _context.Character.FirstAsync(pc => pc.CharacterID == CharacterID));
                return LogicCharacter;
            }
            catch
            {
                throw new Exception("Getting by ID did not complete successfully");
            }
        }

        public async Task CreateCharacterAsync(Guid clientID, string firstName, string lastName)
        {
            try
            {
                _context.Character.Add(Mapper.MapCharacter(new Logic.Objects.Character(clientID, firstName, lastName)));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Couldnt create character for some reason");
            }
        }

        public async Task<Logic.Objects.Client> GetClientByIDAsync(Guid ClientID)
        {
            try
            {
                Logic.Objects.Client LogicClient = Mapper.MapClient(await _context.Client.FirstAsync(c => c.ClientID == ClientID));
                return LogicClient;
            }
            catch
            {
                throw new Exception("did not get client successfully");
            }
        }
        
        public async Task CreateClientAsync(string userName, string email)
        {
            try
            {
                _context.Client.Add(Mapper.MapClient(new Logic.Objects.Client(userName, email)));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Couldn't create client for some reason.");
            }

        }

        public async Task DeleteClientByIDAsync(Guid clientID)
        {
            Client ContextClient = await _context.Client.FirstAsync(c => c.ClientID == clientID);
            _context.Client.Remove(ContextClient);
            await _context.SaveChangesAsync();
        }

        public async Task<Logic.Objects.DungeonMaster> GetDMByDungeonMasterIDAsync(Guid DungeonMasterID)
        {
            try
            {
                Logic.Objects.DungeonMaster LogicDungeonMaster = Mapper.MapDungeonMaster(await _context.DungeonMaster.FirstAsync(dm => dm.DungeonMasterID == DungeonMasterID));
                return LogicDungeonMaster;
            }
            catch
            {
                throw new Exception("Did not get DM successfully");
            }
        }

        public async Task<Logic.Objects.DungeonMaster> GetDMByClientIDAsync(Guid ClientID)
        {
            try
            {
                Logic.Objects.DungeonMaster LogicDungeonMaster = Mapper.MapDungeonMaster(await _context.DungeonMaster.FirstAsync(dm => dm.ClientID == ClientID));
                return LogicDungeonMaster;
            }
            catch
            {
                throw new Exception("Did not get DM successfully");
            }
        }

        public async Task CreateDungeonMasterAsync(Guid clientID)
        {
            try
            {
                _context.DungeonMaster.Add(Mapper.MapDungeonMaster(new Logic.Objects.DungeonMaster(clientID)));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Couldn't create DungeonMaster for some reason");
            }
        }

        public async Task DeleteDungeonMasterByIDAsync(Guid DungeonMasterID)
        {
            try
            {
                DungeonMaster ContextDungeonMaster = await _context.DungeonMaster.FirstAsync(d => d.DungeonMasterID == DungeonMasterID);
                _context.DungeonMaster.Remove(ContextDungeonMaster);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("There was a problem deleting the DM for some reason");
            }
        }

        public async Task<IEnumerable<Logic.Objects.Game>> GetGamesAsync()
        {
            try
            {
                var entityGameList = await _context.Game.ToListAsync();
                return entityGameList.Select(Mapper.MapGame);
            } 
            catch
            {
                throw new Exception("Did not get all games successfully");
            }
        }

        public async Task<Logic.Objects.Game> GetGameByGameIDAsync(Guid GameID)
        {
            try
            {
                Logic.Objects.Game LogicGame = Mapper.MapGame(await _context.Game.FirstAsync(g => g.GameID == GameID));
                return LogicGame;
            }
            catch
            {
                throw new Exception("Did not get game successfully");
            }
        }

        public async Task<List<Logic.Objects.Game>> GetGamesByDungeonMasterIDAsync(Guid DungeonMasterID)
        {
            try
            {
                var entityGameList = await _context.Game.Where(x => x.DungeonMasterID == DungeonMasterID).ToListAsync();
                return entityGameList.Select(Mapper.MapGame).ToList();
            }
            catch
            {
                throw new Exception("Did not get Game from DMID successfully");
            }
        }

        public async Task CreateGameAsync(Guid dungeonMasterID, string gameName)
        {
            try
            {
                _context.Game.Add(Mapper.MapGame(new Logic.Objects.Game(dungeonMasterID, gameName)));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Couldnt create a game for some reason");
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
            catch
            {
                throw new Exception("There was a problem updating the game for some reason");
            }
        }

        public async Task DeleteGameByIDAsync(Guid gameID)
        {
            try 
            {
                _context.Remove(await _context.Game.FirstAsync(g => g.GameID == gameID));
                await _context.SaveChangesAsync();
            }
            catch 
            { 
                throw new Exception("There was a problem deleting the game for some reason"); 
            }
        }

        public async Task<IEnumerable<Logic.Objects.Client>> GetClientsAsync()
        {
            var entityClientList = await _context.Client.ToListAsync();
            return entityClientList.Select(Mapper.MapClient);
        }

        public async Task UpdateCharacterByIDAsync(Guid targetCharacterID, Logic.Objects.Character changedCharacter)
        {
            try
            {
                var targetCharacter = await _context.Character.FirstAsync(g => g.CharacterID == targetCharacterID);
                var madeChange = false;

                if ( !String.IsNullOrEmpty(changedCharacter.FirstName) && targetCharacter.FirstName != changedCharacter.FirstName )
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
            catch
            {
                throw new Exception("There was a problem updating the character for some reason");
            }
        }

        public async Task DeleteCharacterByIDAsync(Guid CharacterID)
        {
            try
            {
                Character ContextCharacter = await _context.Character.FirstAsync(c => c.CharacterID == CharacterID);
                _context.Character.Remove(ContextCharacter);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("There was a problem deleting the character for some reason");
            }
        }
    }
}

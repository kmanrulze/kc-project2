using System;
using System.Collections.Generic;
using System.Text;
using Dbnd.Logic.Interfaces;
using Dbnd.Data.Entities;
using Dbnd.Logic.Objects;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dbnd.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly DbndContext _context;

        public Repository(DbndContext context)
        {
            _context = context;
        }

        public async Task<List<Logic.Objects.Game>> GetAllGamesByDungeonMasterID(Guid DungeonMasterID)
        {
            try
            {
                List<Logic.Objects.Game> LogicGameList = new List<Logic.Objects.Game>();

                foreach (Entities.Game ContextGame in _context.Game.Where(g => g.DungeonMasterId == DungeonMasterID))
                {
                    LogicGameList.Add(await GetGameByGameID(ContextGame.GameId));
                }
                return LogicGameList;
            }
            catch
            {
                throw new Exception("Did not get DM from ID successfully");
            }


        }

        public async Task<Logic.Objects.Character> GetCharacterByCharacterID(Guid CharacterID)
        {
            try
            {
                Logic.Objects.Character LogicCharacter = Mapper.MapCharacter(await _context.Character.FirstAsync(pc => pc.CharacterId == CharacterID));
                return LogicCharacter;
            }
            catch
            {
                throw new Exception("Getting by ID did not complete successfully");
            }


        }

        public async Task<Logic.Objects.Client> GetClientByIDAsync(Guid ClientID)
        {
            try
            {
                Logic.Objects.Client LogicClient = Mapper.MapClient(await _context.Client.FirstAsync(c => c.ClientId == ClientID));
                return LogicClient;
            }
            catch
            {
                throw new Exception("did not get client successfully");
            }


        }

        public async Task<Logic.Objects.DungeonMaster> GetDMByDungeonMasterID(Guid DungeonMasterID)
        {
            try
            {
                Logic.Objects.DungeonMaster LogicDungeonMaster = Mapper.MapDungeonMaster(await _context.DungeonMaster.FirstAsync(dm => dm.DungeonMasterId == DungeonMasterID));
                return LogicDungeonMaster;
            }
            catch
            {
                throw new Exception("Did not get DM successfully");
            }

        }

        public async Task<Logic.Objects.Game> GetGameByGameID(Guid GameID)
        {
            try
            {
                Logic.Objects.Game LogicGame = Mapper.MapGame(await _context.Game.FirstAsync(g => g.GameId == GameID));
                return LogicGame;
            }
            catch
            {
                throw new Exception("Did not get game successfully");
            }

        }
    }
}

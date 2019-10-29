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

        public async Task<Logic.Objects.Character> GetCharacterByPCID(Guid CharacterID)
        {
            Logic.Objects.Character LogicCharacter = Mapper.MapCharacter(await _context.Character.FirstAsync(pc => pc.CharacterId == CharacterID));

            return LogicCharacter;

        }

        public async Task<Logic.Objects.Client> GetClientByIDAsync(Guid ClientID)
        {

            Logic.Objects.Client LogicClient = Mapper.Mapclient(await _context.Client.FirstAsync(c => c.ClientId == ClientID));
            return LogicClient;

        }

        public async Task<Logic.Objects.DungeonMaster> GetDMByDungeonMasterID(Guid DungeonMasterID)
        {
            Logic.Objects.DungeonMaster LogicDungeonMaster = Mapper.MapDM(await _context.DungeonMaster.FirstAsync(dm => dm.DungeonMasterId == DungeonMasterID));
            return LogicDungeonMaster;
        }

        public async Task<Logic.Objects.Game> GetGameByGameID(Guid GameID)
        {
            throw new NotImplementedException();
        }
    }
}

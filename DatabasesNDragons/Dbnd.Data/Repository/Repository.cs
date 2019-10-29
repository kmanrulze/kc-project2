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

        public Logic.Objects.Character GetCharacterByPCID(int PCID)
        {
            Logic.Objects.Character LogicCharacter = new Logic.Objects.Character();

            return null;

        }

        public async Task<Logic.Objects.Client> GetClientByIDAsync(Guid ClientID)
        {

            Logic.Objects.Client LogicClient = Mapper.Mapclient(await _context.Client.FirstAsync(c => c.ClientId == ClientID));
            return LogicClient;

        }

        public Logic.Objects.DungeonMaster GetDMByDungeonMasterID(int DungeonMasterID)
        {
            throw new NotImplementedException();
        }

        public Logic.Objects.Game GetGameByGameID(int GameID)
        {
            throw new NotImplementedException();
        }
    }
}

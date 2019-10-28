using System;
using System.Collections.Generic;
using System.Text;
using Dbnd.Logic.Interfaces;
using Dbnd.Data.Entities;
using Dbnd.Logic.Objects;
using System.Linq;
using System.Threading.Tasks;

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

        public Logic.Objects.Client GetClientByID(Guid ClientID)
        {

            Logic.Objects.Client LogicClient = Mapper.Mapclient(_context.Client.First(c => c.ClientId == ClientID));
            return LogicClient;

        }

        public Logic.Objects.DM GetDMByDungeonMasterID(int DungeonMasterID)
        {
            throw new NotImplementedException();
        }

        public Logic.Objects.Game GetGameByGameID(int GameID)
        {
            throw new NotImplementedException();
        }
    }
}

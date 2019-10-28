using System;
using System.Collections.Generic;
using System.Text;
using Dbnd.Logic.Interfaces;
using Dbnd.Data.Entities;
using Dbnd.Logic.Objects;

namespace Dbnd.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly DbndContext _context;
        public Repository(DbndContext context)
        {
            _context = context;
        }

        public Character GetCharacterByPCID(int PCID)
        {
            throw new NotImplementedException();
        }

        public Logic.Objects.Client GetClientByID(int ClientID)
        {
            throw new NotImplementedException();
        }

        public DM GetDMByDungeonMasterID(int DungeonMasterID)
        {
            throw new NotImplementedException();
        }

        public Game GetGameByGameID(int GameID)
        {
            throw new NotImplementedException();
        }
    }
}

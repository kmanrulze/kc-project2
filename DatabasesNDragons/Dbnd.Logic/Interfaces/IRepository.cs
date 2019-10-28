using Dbnd.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dbnd.Logic.Interfaces
{
    public interface IRepository
    {
        public Client GetClientByID(Guid ClientID);
        public Character GetCharacterByPCID(int PCID);
        public DM GetDMByDungeonMasterID(int DungeonMasterID);
        public Game GetGameByGameID(int GameID);
    }
}

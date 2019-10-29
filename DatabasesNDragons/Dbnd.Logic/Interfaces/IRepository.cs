using Dbnd.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dbnd.Logic.Interfaces
{
    public interface IRepository
    {
        Task<Logic.Objects.Client> GetClientByIDAsync(Guid ClientID);
        public Character GetCharacterByPCID(int PCID);
        public DungeonMaster GetDMByDungeonMasterID(int DungeonMasterID);
        public Game GetGameByGameID(int GameID);
    }
}

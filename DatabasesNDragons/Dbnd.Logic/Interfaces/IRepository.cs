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
        Task<Character> GetCharacterByCharacterID(Guid PCID);
        Task<DungeonMaster> GetDMByDungeonMasterID(Guid DungeonMasterID);
        Task<Game> GetGameByGameID(Guid GameID);
        Task<List<Game>> GetAllGamesByDungeonMasterID(Guid DungeonMasterID);
    }
}

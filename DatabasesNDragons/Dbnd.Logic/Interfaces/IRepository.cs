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
        Task CreateClientAsync(string userName, string email, string passwordHash);
        Task<Character> GetCharacterByCharacterID(Guid CharacterID);
        Task CreateCharacterAsync(Guid clientID, string firstName, string lastName);
        Task<DungeonMaster> GetDMByDungeonMasterID(Guid DungeonMasterID);
        Task CreateDungeonMasterAsync(Guid clientID);
        Task<Game> GetGameByGameID(Guid GameID);
        Task CreateGameAsync(Guid dungeonMasterID, string gameName);
        Task<List<Game>> GetAllGamesByDungeonMasterID(Guid DungeonMasterID);
    }
}

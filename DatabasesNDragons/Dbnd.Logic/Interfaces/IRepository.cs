using Dbnd.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dbnd.Logic.Interfaces
{
    public interface IRepository
    {
        Task<Logic.Objects.Client> GetClientByIDAsync(Guid ClientID);
        Task CreateClientAsync(string userName, string email, string passwordHash);
        Task<Character> GetCharacterByCharacterIDAsync(Guid CharacterID);
        Task CreateCharacterAsync(Guid clientID, string firstName, string lastName);
        Task<DungeonMaster> GetDMByDungeonMasterIDAsync(Guid DungeonMasterID);
        Task<DungeonMaster> GetDMByClientIDAsync(Guid ClientID);
        Task CreateDungeonMasterAsync(Guid clientID);
        Task<Game> GetGameByGameID(Guid GameID);
        IEnumerable<Logic.Objects.Client> GetClients();
        Task CreateGameAsync(Guid DungeonMasterID, string GameName);
        Task<List<Game>> GetAllGamesByDungeonMasterID(Guid DungeonMasterID);
        IEnumerable<Logic.Objects.Character> GetCharacters();
        Task DeleteClientByIDAsync(Guid ClientID);
        Task DeleteCharacterByIDAsync(Guid CharacterID);
        Task DeleteGameByIDAsync(Guid GameID);
        Task DeleteDungeonMasterByIDAsync(Guid DungeonMasterID);
    }
}

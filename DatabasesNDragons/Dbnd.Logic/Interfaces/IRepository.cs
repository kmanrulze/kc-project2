using Dbnd.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dbnd.Logic.Interfaces
{
    public interface IRepository
    {
        Task<Logic.Objects.Client> GetClientByIDAsync(Guid ClientID);
        Task CreateClientAsync(string userName, string email);
        Task<Character> GetCharacterByCharacterIDAsync(Guid CharacterID);
        Task CreateCharacterAsync(Guid clientID, string firstName, string lastName);
        Task<DungeonMaster> GetDMByDungeonMasterIDAsync(Guid DungeonMasterID);
        Task<DungeonMaster> GetDMByClientIDAsync(Guid ClientID);
        Task CreateDungeonMasterAsync(Guid clientID);
        Task<Game> GetGameByGameID(Guid GameID);
        Task<IEnumerable<Logic.Objects.Client>> GetClientsAsync();
        Task CreateGameAsync(Guid DungeonMasterID, string GameName);
        List<Game> GetGamesByDungeonMasterID(Guid DungeonMasterID);
        Task<IEnumerable<Logic.Objects.Character>> GetCharactersAsync();
        Task DeleteClientByIDAsync(Guid ClientID);
        Task DeleteCharacterByIDAsync(Guid CharacterID);
        Task DeleteGameByIDAsync(Guid GameID);
        Task DeleteDungeonMasterByIDAsync(Guid DungeonMasterID);
        Task<IEnumerable<Logic.Objects.Game>> GetGamesAsync();
    }
}

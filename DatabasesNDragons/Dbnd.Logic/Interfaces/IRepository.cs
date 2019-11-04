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
        Task UpdateClientByIDAsync(Guid targetClientID, Client changedClient);
        Task DeleteClientByIDAsync(Guid ClientID);
        Task<IEnumerable<Logic.Objects.Character>> GetCharactersAsync();
        Task<Character> GetCharacterByCharacterIDAsync(Guid CharacterID);
        Task CreateCharacterAsync(Guid clientID, string firstName, string lastName);
        Task UpdateCharacterByIDAsync(Guid targetCharacterID, Character changedCharacter);
        Task DeleteCharacterByIDAsync(Guid CharacterID);
        Task<DungeonMaster> GetDMByDungeonMasterIDAsync(Guid DungeonMasterID);
        Task<DungeonMaster> GetDMByClientIDAsync(Guid ClientID);
        Task CreateDungeonMasterAsync(Guid clientID);
        Task DeleteDungeonMasterByIDAsync(Guid DungeonMasterID);
        Task<Game> GetGameByGameIDAsync(Guid GameID);
        Task<List<Character>> GetAllCharactersInGameByGameIDAsync(Guid gameID);
        Task UpdateGameAsync(Guid targetGameID, Game changedGame);
        Task AddEntryToCharacterGameXRef(Guid gameID, Guid characterID);
        Task<IEnumerable<Logic.Objects.Client>> GetClientsAsync();
        Task CreateGameAsync(Guid DungeonMasterID, string GameName);
        Task<List<Game>> GetGamesByDungeonMasterIDAsync(Guid DungeonMasterID);
        Task<IEnumerable<Logic.Objects.Game>> GetGamesAsync();
        Task DeleteGameByIDAsync(Guid GameID);
        Task RemoveEntryToCharacterGameXRefAsync(Guid gameID, Guid characterID);
    }
}

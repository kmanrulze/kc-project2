using Dbnd.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dbnd.Logic.Interfaces
{
    public interface IRepository
    {
        #region Client
        Task CreateClientAsync(string userName, string email);
        // Task<IEnumerable<Logic.Objects.Client>> GetClientsAsync(); // 'get everything'-type functions are not scalable and have no practical use and are therefore bad
        Task<Logic.Objects.Client> GetClientByIDAsync(Guid clientID);
        Task<Logic.Objects.Client> GetClientByEmailAsync(string email);
        Task<List<Game>> GetGamesByClientIDAsync(Guid clientID);
        Task UpdateClientByIDAsync(Guid targetClientID, Client changedClient);
        Task DeleteClientByIDAsync(Guid clientID);
        #endregion

        #region Character
        Task CreateCharacterAsync(Guid clientID, string firstName, string lastName);
        // Task<IEnumerable<Logic.Objects.Character>> GetCharactersAsync(); // 'get everything'-type functions are not scalable and have no practical use and are therefore bad
        Task<Character> GetCharacterByCharacterIDAsync(Guid characterID);
        Task UpdateCharacterByIDAsync(Guid targetCharacterID, Character changedCharacter);
        Task DeleteCharacterByIDAsync(Guid characterID);
        #endregion

        #region Game
        Task CreateGameAsync(Guid clientID, string gameName);
        Task<Game> GetGameByIDAsync(Guid gameID);
        // Task<IEnumerable<Logic.Objects.Game>> GetGamesAsync(); // 'get everything'-type functions are not scalable and have no practical use and are therefore bad
        // Task<List<Character>> GetAllCharactersInGameByGameIDAsync(Guid gameID); // Flagged for removal - games should now have lists of associated characters in them
        Task UpdateGameAsync(Guid targetGameID, Game changedGame);
        // Task AddEntryToCharacterGameXRef(Guid gameID, Guid characterID);  // Flagged for removal/renaming
        Task DeleteGameByIDAsync(Guid gameID);
        // Task RemoveEntryToCharacterGameXRefAsync(Guid gameID, Guid characterID); // Flagged for removal/renaming
        #endregion

        #region Overview
        Task CreateOverviewAsync(Guid gameID, Guid typeID, string name, string content);
        Task<Overview> GetOverviewByIDAsync(Guid overviewID);
        Task UpdateOverviewByIDAsync(Guid targetOverviewID, Overview changedOverview);
        Task DeleteOverviewByIDAsync(Guid overviewID);
        #endregion
    }
}

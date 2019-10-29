using Dbnd.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dbnd.Data.Repository
{
    public static class Mapper
    {
        public static Character MapCharacter(Entities.Character ContextCharacter)
        {
            Character LogicCharacter = new Character
            {
                CharacterID = ContextCharacter.CharacterId,
                FirstName = ContextCharacter.CharacterFirstName,
                LastName = ContextCharacter.CharacterLastName

            };
            return LogicCharacter;
        }
        public static Client MapClient(Entities.Client ContextClient)
        {
            Client LogicClient = new Client
            {
                UserName = ContextClient.Username,
                PasswordHash = ContextClient.PasswordHash,
                Email = ContextClient.Email,
                ClientID = ContextClient.ClientId
            };

            return LogicClient;
        }
        public static DungeonMaster MapDungeonMaster(Entities.DungeonMaster ContextDungeonMaster)
        {
            DungeonMaster LogicDungeonMaster = new DungeonMaster
            {
                DungeonMasterID = ContextDungeonMaster.DungeonMasterId
            };


            return LogicDungeonMaster;
        }
        public static Game MapGame(Entities.Game ContextGame)
        {
            Game LogicGame = new Game
            {
                DungeonMasterId = ContextGame.DungeonMasterId,
                GameId = ContextGame.GameId,
                GameName = ContextGame.GameName
            };
            return LogicGame;
        }
    }
}

using Dbnd.Logic.Objects;

namespace Dbnd.Data.Repository
{
    public static class Mapper
    {
        public static Character MapCharacter(Entities.Character ContextCharacter)
        {
            Character LogicCharacter = new Character(ContextCharacter.ClientID, ContextCharacter.FirstName, ContextCharacter.LastName)
            {
                CharacterID = ContextCharacter.CharacterID
            };
            return LogicCharacter;
        }

        public static Entities.Character MapCharacter(Character ContextCharacter)
        {
            Entities.Character EntityCharacter = new Entities.Character
            {
                CharacterID = ContextCharacter.CharacterID,
                ClientID = ContextCharacter.ClientID,
                FirstName = ContextCharacter.FirstName,
                LastName = ContextCharacter.LastName
            };

            return EntityCharacter;
        }

        public static Client MapClient(Entities.Client ContextClient)
        {
            Client LogicClient = new Client(ContextClient.UserName, ContextClient.Email, ContextClient.PasswordHash)
            {
                ClientID = ContextClient.ClientID
            };

            return LogicClient;
        }
        public static Entities.Client MapClient(Client ContextClient)
        {
            Entities.Client EntitiesClient = new Entities.Client
            {
                UserName = ContextClient.UserName,
                PasswordHash = ContextClient.PasswordHash,
                Email = ContextClient.Email,
                ClientID = ContextClient.ClientID
            };

            return EntitiesClient;
        }

        public static DungeonMaster MapDungeonMaster(Entities.DungeonMaster ContextDungeonMaster)
        {
            DungeonMaster LogicDungeonMaster = new DungeonMaster(ContextDungeonMaster.ClientID)
            {
                DungeonMasterID = ContextDungeonMaster.DungeonMasterID
            };
            return LogicDungeonMaster;
        }

        public static Entities.DungeonMaster MapDungeonMaster(DungeonMaster ContextDungeonMaster)
        {
            Entities.DungeonMaster EntityDungeonMaster = new Entities.DungeonMaster
            {
                DungeonMasterID = ContextDungeonMaster.DungeonMasterID,
                ClientID = ContextDungeonMaster.ClientID
            };
            return EntityDungeonMaster;
        }

        public static Game MapGame(Entities.Game ContextGame)
        {
            Game LogicGame = new Game
            {
                DungeonMasterID = ContextGame.DungeonMasterID,
                GameID = ContextGame.GameID,
                GameName = ContextGame.GameName
            };
            return LogicGame;
        }

        public static Entities.Game MapGame(Game ContextGame)
        {
            Entities.Game EntityGame = new Entities.Game
            {
                GameID = ContextGame.GameID,
                GameName = ContextGame.GameName,
                DungeonMasterID = ContextGame.DungeonMasterID
            };
            return EntityGame;
        }
    }
}

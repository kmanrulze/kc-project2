using Dbnd.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dbnd.Data.Repository
{
    public static class Mapper
    {
        public static Character MapCharacter()
        {
            return null;
        }
        public static Client Mapclient(Entities.Client ContextClient)
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
        public static DungeonMaster MapDM(Entities.DungeonMaster ContextDungeonMaster)
        {
            DungeonMaster LogicDungeonMaster = new DungeonMaster
            {
                DungeonMasterID = ContextDungeonMaster.DungeonMasterId
            };


            return LogicDungeonMaster;
        }
        public static Game MapGame()
        {
            return null;
        }
    }
}

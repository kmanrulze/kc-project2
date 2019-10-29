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
            Client LogicClient = new Client();

            LogicClient.UserName = ContextClient.Username;
            LogicClient.PasswordHash = ContextClient.PasswordHash;
            LogicClient.Email = ContextClient.Email;
            LogicClient.ClientID = ContextClient.ClientId; 

            return LogicClient;
        }
        public static DungeonMaster MapDM()
        {
            return null;
        }
        public static Game MapGame()
        {
            return null;
        }
    }
}

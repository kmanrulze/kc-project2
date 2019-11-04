using System;
using System.Collections.Generic;

namespace Dbnd.Logic.Objects
{
    public class DungeonMaster
    {
        public Guid dungeonMasterID { get; set; }
        public Guid DungeonMasterID 
        {
            get { return dungeonMasterID; }
            set { dungeonMasterID = value; } 
        }
        private List<Game> games = new List<Game>();

        public List<Game> Games
        {
            get { return games; }
            set { games = value; }
        }
        public Guid ClientID { get; set; }

        public DungeonMaster(Guid clientID)
        {
            DungeonMasterID = Guid.NewGuid();
            ClientID = clientID;
        }

        public DungeonMaster() { }
    }
}

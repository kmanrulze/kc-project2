using System;
using System.Collections.Generic;
using System.Text;

namespace Dbnd.Logic.Objects
{
    public class DungeonMaster
    {
        private Guid dungeonMasterID = Guid.NewGuid();
        private List<Game> games = new List<Game>();

        public List<Game> Games
        {
            get { return games; }
            set { games = value; }
        }

        public Guid DungeonMasterID
        {
            get { return dungeonMasterID; }
            set { dungeonMasterID = value; }
        }
        public Guid ClientId { get; set; }
    }
}

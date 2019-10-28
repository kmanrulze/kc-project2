using System;
using System.Collections.Generic;
using System.Text;

namespace Dbnd.Logic.Objects
{
    public class DM
    {
        private Guid dungeonMasterID = new Guid();
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
    }
}

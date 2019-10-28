using System;
using System.Collections.Generic;
using System.Text;

namespace Dbnd.Logic.Objects
{
    public class DM
    {
        public int DungeonMasterID { get; set; }
        private List<Game> games = new List<Game>();

        public List<Game> Games
        {
            get { return games; }
            set { games = value; }
        }
    }
}

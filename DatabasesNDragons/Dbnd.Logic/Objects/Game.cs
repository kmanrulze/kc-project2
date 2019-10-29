using System;
using System.Collections.Generic;
using System.Text;

namespace Dbnd.Logic.Objects
{
    public class Game
    {
        private Guid gameID = Guid.NewGuid();

        public Guid GameId
        {
            get { return gameID; }
            set { gameID = value; }
        }
        public string GameName { get; set; }
        public Guid DungeonMasterId { get; set; }
    }
}

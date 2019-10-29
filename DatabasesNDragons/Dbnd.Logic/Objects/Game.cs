using System;
using System.Collections.Generic;
using System.Text;

namespace Dbnd.Logic.Objects
{
    public class Game
    {
        public Guid GameID { get; set; }
        public string GameName { get; set; }

        // Foreign Key for DungeonMaster
        public Guid DungeonMasterID { get; set; }

        public Game()
        {
            GameID = Guid.NewGuid();
            DungeonMasterID = Guid.NewGuid();
        }


    }
}

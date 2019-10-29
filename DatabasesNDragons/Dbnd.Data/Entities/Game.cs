using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dbnd.Data.Entities
{
    public class Game
    {
        [Key]
        public Guid GameId { get; set; }
        public string GameName { get; set; }

        // Foreign Key for DungeonMaster
        public Guid DungeonMasterId { get; set; }
        public DungeonMaster DungeonMaster { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dbnd.Data.Entities
{
    class Game
    {
        [Key]
        public Guid GameId { get; set; }
        [ForeignKey("DungeonMasterRefId")]
        public Guid DungeonMasterId { get; set; }

    }
}

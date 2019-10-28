using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dbnd.Data.Entities
{
    class DungeonMaster
    {
        [Key]
        public Guid DungeonMasterId { get; set; }
        [ForeignKey("ClientRefId")]
        public Guid ClientId { get; set; }
    }
}

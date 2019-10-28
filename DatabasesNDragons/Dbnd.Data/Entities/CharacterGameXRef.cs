using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dbnd.Data.Entities
{
    class CharacterGameXRef
    {
        [ForeignKey("GameRefId")]
        [Key]
        public Guid GameId { get; set; }

        [ForeignKey("ClientRefId")]
        [Key]
        public Guid ClientId { get; set; }

    }
}

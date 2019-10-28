using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dbnd.Data.Entities
{
    class Character
    {
        [Key]
        public Guid CharacterId { get; set; }
        [ForeignKey("ClientRefId")]
        public Guid ClientId { get; set; }
        public String CharacterFirstName { get; set; }
        public String CharacterLastName { get; set; }

    }
}

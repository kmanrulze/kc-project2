using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dbnd.Data.Entities
{
    public class Character
    {
        [Key]
        public Guid CharacterId { get; set; }
        
        public String CharacterFirstName { get; set; }
        public String CharacterLastName { get; set; }

        // Foreign Key for Client
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

    }
}

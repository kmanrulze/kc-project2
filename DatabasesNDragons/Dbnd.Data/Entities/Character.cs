using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dbnd.Data.Entities
{
    public class Character
    {
        [Key]
        public Guid CharacterID { get; set; }
        
        public String FirstName { get; set; }
        public String LastName { get; set; }

        // Foreign Key for Client
        public Guid ClientID { get; set; }
        public Client Client { get; set; }

    }
}

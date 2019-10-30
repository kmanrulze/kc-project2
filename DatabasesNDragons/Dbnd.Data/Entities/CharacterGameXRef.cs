using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dbnd.Data.Entities
{
    public class CharacterGameXRef
    {
        // Foreign Key
        public Guid GameID { get; set; }
        public Game Game { get; set; }

        // Foreign Key
        public Guid ClientID { get; set; }
        public Client Client { get; set; }

    }
}

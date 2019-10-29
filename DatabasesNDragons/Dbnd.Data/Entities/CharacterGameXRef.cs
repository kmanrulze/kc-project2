using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dbnd.Data.Entities
{
    public class CharacterGameXRef
    {
        // Foreign Key
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        // Foreign Key
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

    }
}

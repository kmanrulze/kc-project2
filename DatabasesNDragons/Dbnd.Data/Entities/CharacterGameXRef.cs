using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dbnd.Data.Entities
{
    class CharacterGameXRef
    {
        [Key]
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        [Key]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

    }
}

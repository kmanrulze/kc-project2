using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dbnd.Data.Entities
{
    public class Game
    {
        [Key]
        public Guid GameID { get; set; }
        public string GameName { get; set; }

        // Foreign Key for Client
        public Guid ClientID { get; set; }
        public Client Client { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<Overview> Overviews { get; set; }

    }
}

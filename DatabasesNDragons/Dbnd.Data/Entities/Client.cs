using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dbnd.Data.Entities
{
    public class Client
    {
        [Key]
        public Guid ClientID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        // Owned Characters
        public virtual ICollection<Character> Characters { get; set; } = new HashSet<Character>();
        // Owned Games
        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}

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

        public virtual ICollection<Character> Characters { get; set; }

    }
}

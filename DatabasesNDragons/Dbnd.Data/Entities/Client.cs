using System;
using System.ComponentModel.DataAnnotations;

namespace Dbnd.Data.Entities
{
    public class Client
    {
        [Key]
        public Guid ClientId { get; set; }
        public string ClientLogin { get; set; }

    }
}

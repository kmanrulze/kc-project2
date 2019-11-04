using System;

namespace Dbnd.Api.Models
{
    public class ClientModel
    {
        public Guid ClientID { get; set; }
        public string UserName { get; set; }
        public string  Email { get; set; }
        public string PasswordHash { get; set; }
    }
}

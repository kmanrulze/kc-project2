using System;
using System.Collections.Generic;

namespace Dbnd.Logic.Objects
{
    public class Client
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Guid ClientID { get; set; }
        private List<Character> characters = new List<Character>();
        public Client()
        {
            ClientID = Guid.NewGuid();
        }
        public List<Character> Characters
        {
            get { return characters; }
            set { characters = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dbnd.Logic.Objects
{
    public class Client
    {
        public Guid ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }

        public string UserName { get; set; }
        public string Email { get; set; }

        private Guid clientID = Guid.NewGuid();
        private List<Character> characters = new List<Character>();

        public string PasswordHash { get; set; }
        
        public List<Character> Characters
        {
            get { return characters; }
            set { characters = value; }
        }
    }
}

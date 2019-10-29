using System;
using System.Collections.Generic;

namespace Dbnd.Logic.Objects
{
    public class Client
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        private string passwordHash;
        private Guid clientID;
        private List<Character> characters = new List<Character>();

        public Guid ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }
        public string PasswordHash
        {
            get { return passwordHash; }
            set { passwordHash = value; }
        }
        public List<Character> Characters
        {
            get { return characters; }
            set { characters = value; }
        }
    }
}

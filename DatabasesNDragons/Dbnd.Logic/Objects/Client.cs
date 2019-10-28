using System;
using System.Collections.Generic;
using System.Text;

namespace Dbnd.Logic.Objects
{
    public class Client
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        private HashCode passwordHash = new HashCode();
        private Guid clientID = new Guid();
        private List<Character> characters = new List<Character>();
        private DM dmID = new DM();

        public HashCode PasswordHash
        {
            get { return passwordHash; }
            set { passwordHash = value; }
        }
        public Guid ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }
        public List<Character> Characters
        {
            get { return characters; }
            set { characters = value; }
        }
        public DM DMID
        {
            get { return dmID; }
            set { dmID = value; }
        }
    }
}

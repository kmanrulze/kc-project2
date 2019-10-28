using System;
using System.Collections.Generic;
using System.Text;

namespace Dbnd.Logic.Objects
{
    public class Client
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        private List<Character> characters = new List<Character>();
        private DM dm = new DM();

        public List<Character> Characters
        {
            get { return characters; }
            set { characters = value; }
        }
        public DM DM
        {
            get { return dm; }
            set { dm = value; }
        }
    }
}

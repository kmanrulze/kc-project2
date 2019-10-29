using System;
using System.Collections.Generic;
using System.Text;

namespace Dbnd.Logic.Objects
{
    public class Character
    {
        private Guid characterID = Guid.NewGuid();

        public Guid CharacterID
        {
            get { return characterID; }
            set { characterID = value; }
        }
        public Guid ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}

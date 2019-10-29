using System;
using System.Collections.Generic;
using System.Text;

namespace Dbnd.Logic.Objects
{
    public class Character
    {
        public Guid CharacterID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Character()
        {
            CharacterID = Guid.NewGuid();
        }
    }
    //test
}

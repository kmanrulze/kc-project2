﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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

        // 8-20 alphanumeric . _ chars
        // . and _ can not be leading or trailing
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // 'Not Null' checks for properties that are not autogenerated
        public bool RequiredFieldsNotNull()
        {
            if (String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Valid Name checks
        // 8-20 alphanumeric . _ chars
        // . and _ can not be leading or trailing
        bool IsValidFirstName()
        {
            Regex regex = new Regex(@"^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$");
            Match match = regex.Match(FirstName);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool IsValidLastName()
        {
            Regex regex = new Regex(@"^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$");
            Match match = regex.Match(LastName);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

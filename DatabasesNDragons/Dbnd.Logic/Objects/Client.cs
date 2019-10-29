﻿using System;
using System.Collections.Generic;

namespace Dbnd.Logic.Objects
{
    public class Client
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        private string passwordHash;
        private Guid clientID = new Guid();
        private List<Character> characters = new List<Character>();

        public string PasswordHash
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

        // 'Not Null' checks for properties that are not autogenerated
        public bool RequiredFieldsNotNull()
        {
            if (String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(PasswordHash))
            {
                return false;
            } 
            else
            {
                return true;
            }
        }
    }
}

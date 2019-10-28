﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Dbnd.Data.Entities
{
    public class Client
    {
        [Key]
        public Guid ClientId { get; set; }
        public string Username { get; set; }
        public HashCode PasswordHash { get; set; }
        public string Email { get; set; }

    }
}

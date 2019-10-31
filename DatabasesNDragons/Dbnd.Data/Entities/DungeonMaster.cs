﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Dbnd.Data.Entities
{
    public class DungeonMaster
    {
        [Key]
        public Guid DungeonMasterID { get; set; }

        // Foreign key for Client
        public Guid ClientID { get; set; }
        public Client Client { get; set; }
    }
}

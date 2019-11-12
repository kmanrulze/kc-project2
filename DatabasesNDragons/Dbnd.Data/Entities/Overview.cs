using System;
using System.ComponentModel.DataAnnotations;

namespace Dbnd.Data.Entities
{
    public class Overview
    {
        [Key]
        public Guid OverviewID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        // Foreign Key for GameID
        public Guid GameID { get; set; }
        public Game Game { get; set; }

        //Foreign Key for OverviewType
        public Guid TypeID { get; set; }
        public OverviewType OverviewType { get; set; }
    }
}

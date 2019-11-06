using System;
using System.ComponentModel.DataAnnotations;

namespace Dbnd.Data.Entities
{
    public class OverviewType
    {
        [Key]
        public Guid TypeID { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dbnd.Api
{
    [BindProperties]
    public class UserProfile
    {
        public string nickname { get; set; }
        public string name { get; set; }
        public string picture { get; set; }
        public DateTime updated_at { get; set; }
        public string email { get; set; }
        public bool email_verified { get; set; }
        public string sub { get; set; }
    }
}

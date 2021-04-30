using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebTest.Models
{
    public class Member
    {
        public string id { get; set; }
        public string memberName { get; set; }
        public string password { get; set; }
        public string right { get; set; }
    }
}
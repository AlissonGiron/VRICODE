using System;
using System.Collections.Generic;
using System.Text;

namespace VRICODE.Models
{
    public class UserClass
    {
        public int NidUser { get; set; }
        public User User { get; set; }

        public int NidClass { get; set; }
        public Class Class { get; set; }

        public UserClassPrivilege UserClassPrivilege { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace VRICODE.Models
{
    public class Class
    {
        public int NidClass { get; set; }
        public string NamClass { get; set; }

        public ICollection<UserClass> UserClasses { get; set; }
        public ICollection<ProblemClass> ProblemClasses { get; set; }
    }
}

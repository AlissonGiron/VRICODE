using System.Collections.Generic;

namespace VRICODE.Models
{
    public class User
    {
        public int NidUser { get; set; }

        public string NamUser { get; set; }

        public string DesEmail { get; set; }
        public string DesPassword { get; set; }

        public ICollection<UserClass> UserClasses { get; set; }
        public ICollection<ProblemUser> UserProblems { get; set; }
    }
}

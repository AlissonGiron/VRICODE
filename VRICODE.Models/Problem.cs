using System;
using System.Collections.Generic;
using System.Text;

namespace VRICODE.Models
{
    public class Problem
    {
        public int NidProblem { get; set; }

        public string DesTitle { get; set; }
        public string DesProblem { get; set; }

        public ICollection<ProblemClass> ProblemClasses { get; set; }
        public ICollection<ProblemTest> ProblemTests { get; set; }
        public ICollection<ProblemUser> ProblemUsers { get; set; }
    }
}

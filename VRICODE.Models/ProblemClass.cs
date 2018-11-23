using System;
using System.Collections.Generic;
using System.Text;

namespace VRICODE.Models
{
    public class ProblemClass
    {
        public int NidProblem { get; set; }
        public Problem Problem { get; set; }

        public int NidClass { get; set; }
        public Class Class { get; set; }
    }
}

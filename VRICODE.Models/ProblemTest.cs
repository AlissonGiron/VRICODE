using System;
using System.Collections.Generic;
using System.Text;

namespace VRICODE.Models
{
    public class ProblemTest
    {
        public int NidProblemTest { get; set; }

        public int NidProblem { get; set; }
        public Problem Problem { get; set; }

        public string DesTestInput { get; set; }
        public string DesTestExpectedOutput { get; set; }

        public bool FlgVisibleToUser { get; set; }
    }
}

using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class ProblemTestCore : VRICODECoreBase<ProblemTest>
    {
        public ProblemTestCore(IProblemTestRepository ARepository) : base(ARepository)
        {

        }
    }
}

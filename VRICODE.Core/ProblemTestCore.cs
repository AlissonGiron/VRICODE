using VRICODE.Interfaces.Core;
using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class ProblemTestCore : VRICODECoreBase<ProblemTest>, IProblemTestCore
    {
        public ProblemTestCore(IProblemTestRepository ARepository) : base(ARepository)
        {

        }
    }
}

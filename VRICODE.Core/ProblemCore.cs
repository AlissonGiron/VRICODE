using VRICODE.Interfaces.Core;
using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class ProblemCore : VRICODECoreBase<Problem>, IProblemCore
    {
        public ProblemCore(IProblemRepository ARepository) : base(ARepository)
        {

        }
    }
}

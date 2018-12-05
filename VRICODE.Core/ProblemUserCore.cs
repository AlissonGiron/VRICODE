using VRICODE.Interfaces.Core;
using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class ProblemUserCore : VRICODECoreBase<ProblemUser>, IProblemUserCore
    {
        public ProblemUserCore(IProblemUserRepository ARepository) : base(ARepository)
        {

        }
    }
}

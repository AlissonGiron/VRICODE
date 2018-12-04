using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class ProblemUserCore : VRICODECoreBase<ProblemUser>
    {
        public ProblemUserCore(IProblemUserRepository ARepository) : base(ARepository)
        {

        }
    }
}

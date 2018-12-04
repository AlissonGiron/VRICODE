using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class ProblemCore : VRICODECoreBase<Problem>
    {
        public ProblemCore(IProblemRepository ARepository) : base(ARepository)
        {

        }
    }
}

using VRICODE.Interfaces.Core;
using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class ProblemClassCore : VRICODECoreBase<ProblemClass>, IProblemClassCore
    {
        public ProblemClassCore(IProblemClassRepository ARepository) : base(ARepository)
        {

        }
    }
}

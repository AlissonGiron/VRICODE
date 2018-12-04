using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class ProblemClassCore : VRICODECoreBase<ProblemClass>
    {
        public ProblemClassCore(IProblemClassRepository ARepository) : base(ARepository)
        {

        }
    }
}

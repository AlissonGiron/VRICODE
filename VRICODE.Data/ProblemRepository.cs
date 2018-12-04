using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Data
{
    public class ProblemRepository : VRICODERepositoryBase<Problem>, IProblemRepository
    {
        public ProblemRepository(VRICODEContext AContext) : base(AContext)
        {

        }
    }
}

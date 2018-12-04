using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Data
{
    public class ProblemTestRepository : VRICODERepositoryBase<ProblemTest>, IProblemTestRepository
    {
        public ProblemTestRepository(VRICODEContext AContext) : base(AContext)
        {

        }
    }
}

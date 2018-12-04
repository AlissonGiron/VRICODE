using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Data
{
    public class ProblemClassRepository : VRICODERepositoryBase<ProblemClass>, IProblemClassRepository
    {
        public ProblemClassRepository(VRICODEContext AContext) : base(AContext)
        {

        }
    }
}

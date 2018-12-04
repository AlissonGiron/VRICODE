using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Data
{
    public class ProblemUserRepository : VRICODERepositoryBase<ProblemUser>, IProblemUserRepository
    {
        public ProblemUserRepository(VRICODEContext AContext) : base(AContext)
        {

        }
    }
}

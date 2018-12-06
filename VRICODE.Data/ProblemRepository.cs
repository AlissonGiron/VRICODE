using Microsoft.EntityFrameworkCore;
using System.Linq;
using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Data
{
    public class ProblemRepository : VRICODERepositoryBase<Problem>, IProblemRepository
    {
        public ProblemRepository(VRICODEContext AContext) : base(AContext)
        {
        }

        public void CreateProblemClass(ProblemClass AProblemClass)
        {
            FContext.Add(AProblemClass);
            FContext.SaveChanges();
        }

        public override Problem Get(params object[] AKeys)
        {
            return FDbSet
                .Include(p => p.ProblemTests)
                .FirstOrDefault(p => p.NidProblem == (int)AKeys[0]);
        }
    }
}

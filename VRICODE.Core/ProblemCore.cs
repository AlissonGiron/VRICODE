using VRICODE.Interfaces.Core;
using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class ProblemCore : VRICODECoreBase<Problem>, IProblemCore
    {
        private IProblemRepository Repository => (IProblemRepository) FRepository; 

        public ProblemCore(IProblemRepository ARepository) : base(ARepository)
        {
        }

        public void CreateProblemClass(ProblemClass AProblemClass)
        {
            Repository.CreateProblemClass(AProblemClass);
        }
    }
}

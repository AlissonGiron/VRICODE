using VRICODE.Models;

namespace VRICODE.Interfaces.Data
{
    public interface IProblemRepository : IVRICODERepositoryBase<Problem>
    {
        void CreateProblemClass(ProblemClass AProblemClass);
    }
}

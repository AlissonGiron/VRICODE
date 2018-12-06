using VRICODE.Models;

namespace VRICODE.Interfaces.Core
{
    public interface IProblemCore : IVRICODECoreBase<Problem>
    {
        void CreateProblemClass(ProblemClass AProblemClass);
    }
}

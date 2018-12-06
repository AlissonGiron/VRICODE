using VRICODE.Interfaces.Core;
using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class ClassCore : VRICODECoreBase<Class>, IClassCore
    {
        private IClassRepository Repository
        {
            get
            {
                return (IClassRepository)FRepository;
            }
        }

        public ClassCore(IClassRepository ARepository) : base(ARepository)
        {
        }

        public void CreateUserClass(UserClass AUserClass)
        {
            Repository.CreateUserClass(AUserClass);
        }
    }
}

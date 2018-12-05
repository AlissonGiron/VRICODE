using VRICODE.Interfaces.Core;
using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class ClassCore : VRICODECoreBase<Class>, IClassCore
    {
        public ClassCore(IClassRepository ARepository) : base(ARepository)
        {

        }
    }
}

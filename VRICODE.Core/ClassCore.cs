using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class ClassCore : VRICODECoreBase<Class>
    {
        public ClassCore(IClassRepository ARepository) : base(ARepository)
        {

        }
    }
}

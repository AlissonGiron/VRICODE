using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Data
{
    public class ClassRepository : VRICODERepositoryBase<Class>, IClassRepository
    {
        public ClassRepository(VRICODEContext AContext) : base(AContext)
        {

        }
    }
}

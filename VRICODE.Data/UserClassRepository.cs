using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Data
{
    public class UserClassRepository : VRICODERepositoryBase<UserClass>, IUserClassRepository
    {
        public UserClassRepository(VRICODEContext AContext) : base(AContext)
        {

        }
    }
}

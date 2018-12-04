using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Data
{
    public class UserRepository : VRICODERepositoryBase<User>, IUserRepository
    {
        public UserRepository(VRICODEContext AContext) : base(AContext)
        {

        }
    }
}

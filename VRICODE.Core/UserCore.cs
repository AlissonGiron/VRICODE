using VRICODE.Interfaces.Core;
using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class UserCore : VRICODECoreBase<User>, IUserCore
    {
        public UserCore(IUserRepository ARepository) : base(ARepository)
        {

        }
    }
}

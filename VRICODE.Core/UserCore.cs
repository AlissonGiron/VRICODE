using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class UserCore : VRICODECoreBase<User>
    {
        public UserCore(IUserRepository ARepository) : base(ARepository)
        {

        }
    }
}

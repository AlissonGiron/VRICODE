using VRICODE.Interfaces.Core;
using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class UserClassCore : VRICODECoreBase<UserClass>, IUserClassCore
    {
        public UserClassCore(IUserClassRepository ARepository) : base(ARepository)
        {

        }
    }
}

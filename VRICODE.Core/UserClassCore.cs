using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Core
{
    public class UserClassCore : VRICODECoreBase<UserClass>
    {
        public UserClassCore(IUserClassRepository ARepository) : base(ARepository)
        {

        }
    }
}

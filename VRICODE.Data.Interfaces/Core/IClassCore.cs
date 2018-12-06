using VRICODE.Models;

namespace VRICODE.Interfaces.Core
{
    public interface IClassCore : IVRICODECoreBase<Class>
    {
        void CreateUserClass(UserClass AUserClass);
    }
}

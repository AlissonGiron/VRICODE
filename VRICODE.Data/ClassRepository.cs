using System.Linq;
using Microsoft.EntityFrameworkCore;
using VRICODE.Interfaces.Data;
using VRICODE.Models;

namespace VRICODE.Data
{
    public class ClassRepository : VRICODERepositoryBase<Class>, IClassRepository
    {
        public ClassRepository(VRICODEContext AContext) : base(AContext)
        {

        }

        public void CreateUserClass(UserClass AUserClass)
        {
            FContext.Add(AUserClass);
            FContext.SaveChanges();
        }

        public override Class Get(params object[] AKeys)
        {
            return FContext.Classes.Include(s => s.ProblemClasses).AsQueryable().FirstOrDefault(s => s.NidClass == (int) AKeys.FirstOrDefault());
        }


    }
}

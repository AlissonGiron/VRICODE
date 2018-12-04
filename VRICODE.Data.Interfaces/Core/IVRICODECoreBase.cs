using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace VRICODE.Interfaces.Core
{
    public interface IVRICODECoreBase<T> : IDisposable where T : class
    {
        T Get(params object[] AKeys);
        ICollection<T> FindBy(Expression<Func<T, bool>> AFilter, bool AAsNoTracking);
        void Create(T AModel);
        T Edit(T AModel);
        void Delete(T AModel);
        void Save();
    }
}

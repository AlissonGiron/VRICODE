using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace VRICODE.Interfaces.Data
{
    public interface IVRICODERepositoryBase<T> : IDisposable where T : class
    {
        bool InTransaction { get; }

        T Get(params object[] AKeys);
        ICollection<T> FindBy(Expression<Func<T, bool>> AFilter = null, bool AAsNoTracking = false);
        void Add(T AModel);
        T Edit(T AModel);
        void Delete(T AModel);
        void Save();
        void StartTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}

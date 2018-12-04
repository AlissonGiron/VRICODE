using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VRICODE.Interfaces.Core;
using VRICODE.Interfaces.Data;

namespace VRICODE.Core
{
    public abstract class VRICODECoreBase<T> : IVRICODECoreBase<T> where T : class
    {
        protected IVRICODERepositoryBase<T> FRepository;

        public VRICODECoreBase(IVRICODERepositoryBase<T> ARepository)
        {
            FRepository = ARepository;
        }

        public virtual T Get(params object[] AKeys)
        {
            return FRepository.Get(AKeys);
        }

        public virtual ICollection<T> FindBy(Expression<Func<T, bool>> AFilter, bool AAsNoTracking)
        {
            return FRepository.FindBy(AFilter, AAsNoTracking);
        }

        public virtual void Create(T AModel)
        {
            FRepository.Add(AModel);
        }

        public virtual T Edit(T AModel)
        {
            return FRepository.Edit(AModel);
        }

        public virtual void Delete(T AModel)
        {
            FRepository.Delete(AModel);
        }

        public virtual void Save()
        {
            FRepository.Save();
        }

        public void Dispose()
        {
            FRepository.Dispose();
        }
    }
}

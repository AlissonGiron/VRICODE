using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VRICODE.Interfaces.Data;

namespace VRICODE.Data
{
    public abstract class VRICODERepositoryBase<T> : IVRICODERepositoryBase<T> where T : class
    {
        protected VRICODEContext FContext;
        protected DbSet<T> FDbSet;

        protected IDbContextTransaction FCurrentTransaction;

        public bool InTransaction => FCurrentTransaction != null;

        public VRICODERepositoryBase(VRICODEContext AContext)
        {
            FContext = AContext;
            FDbSet = FContext.Set<T>();
        }

        public virtual T Get(params object[] AKeys)
        {
            return FDbSet.Find(AKeys);
        }

        public virtual ICollection<T> FindBy(Expression<Func<T, bool>> AFilter = null, bool AAsNoTracking = false)
        {
            IQueryable<T> LQuery = FDbSet.AsQueryable();

            if (AFilter != null)
            {
                LQuery = LQuery.Where(AFilter);
            }

            if (AAsNoTracking)
            {
                LQuery = LQuery.AsNoTracking();
            }

            return LQuery.ToList();
        }

        public virtual void Add(T AModel)
        {
            FDbSet.Add(AModel);
        }

        public virtual T Edit(T AModel)
        {
            FContext.Entry(AModel).State = EntityState.Modified;
            return AModel;
        }

        public virtual void Delete(T AModel)
        {
            FDbSet.Remove(AModel);
        }

        public virtual void Save()
        {
            FContext.SaveChanges();
        }

        public virtual void StartTransaction()
        {
            FCurrentTransaction = FContext.Database.BeginTransaction();
        }

        public virtual void CommitTransaction()
        {
            if (FCurrentTransaction != null)
            {
                FCurrentTransaction.Commit();
                FCurrentTransaction.Dispose();

                FCurrentTransaction = null;
            }
        }

        public virtual void RollbackTransaction()
        {
            if (FCurrentTransaction != null)
            {
                FCurrentTransaction.Rollback();
                FCurrentTransaction.Dispose();

                FCurrentTransaction = null;
            }
        }

        public void Dispose()
        {
            FContext.Dispose();
        }
    }
}

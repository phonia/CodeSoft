using ERP.Infrastructure;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Transactions;

namespace ERP.Repository
{
    public class EFUnitOfWork:IEFUnitOfWork,IDisposable
    {
        //private Queue<UnitItem> _ItemQueue = new Queue<UnitItem>();
        //private DbContext _dataContext = null;

        //public EFUnitOfWork()
        //{
        //    _dataContext = new DataContext();
        //}

        ////public EFUnitOfWork(DbContext dbContext)
        ////{
        ////    if (dbContext == null) throw new ArgumentNullException();
        ////    _dataContext = dbContext;
        ////}

        //public void RegisterAdd(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        //{
        //    if (_ItemQueue == null)
        //        _ItemQueue = new Queue<UnitItem>();
        //    UnitItem unitItem = new UnitItem() { Entity = entity, UnitOfWorkRepository = unitOfWorkRepository, Operator = UnitOperator.Add };
        //    if (_ItemQueue.Contains(unitItem))
        //    {
        //        throw new Exception("exist Entity in RegistorAdd!");
        //    }
        //    else
        //    {
        //        _ItemQueue.Enqueue(unitItem);
        //    }
        //}

        //public void RegisterRemove(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        //{
        //    if (_ItemQueue == null)
        //        _ItemQueue = new Queue<UnitItem>();
        //    UnitItem unitItem = new UnitItem() { Entity = entity, UnitOfWorkRepository = unitOfWorkRepository, Operator = UnitOperator.Del };
        //    if (_ItemQueue.Contains(unitItem))
        //    {
        //        throw new Exception("exist Entity in RegistorDel!");
        //    }
        //    else
        //    {
        //        _ItemQueue.Enqueue(unitItem);
        //    }
        //}

        //public void RegisterSave(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        //{
        //    if (_ItemQueue == null)
        //        _ItemQueue = new Queue<UnitItem>();
        //    UnitItem unitItem = new UnitItem() { Entity = entity, UnitOfWorkRepository = unitOfWorkRepository, Operator = UnitOperator.Save };
        //    if (_ItemQueue.Contains(unitItem))
        //    {
        //        throw new Exception("exist Entity in RegistorSave!");
        //    }
        //    else
        //    {
        //        _ItemQueue.Enqueue(unitItem);
        //    }
        //}

        //public void Commit()
        //{
        //    if (_ItemQueue != null && _ItemQueue.Count > 0)
        //    {
        //        using (DbContextTransaction trans = _dataContext.Database.BeginTransaction())
        //        {
        //            int changes=_ItemQueue.Count;
        //            while (_ItemQueue.Count > 0)
        //            {
        //                UnitItem item = _ItemQueue.Dequeue();
        //                switch (item.Operator)
        //                {
        //                    case UnitOperator.Add:
        //                        item.UnitOfWorkRepository.PersistAdd(item.Entity);
        //                        break;
        //                    case UnitOperator.Del:
        //                        item.UnitOfWorkRepository.PersistRemove(item.Entity);
        //                        break;
        //                    case UnitOperator.Save:
        //                        item.UnitOfWorkRepository.PersistSave(item.Entity);
        //                        break;
        //                    default: break;
        //                }
        //            }
        //            if (_dataContext.SaveChanges() < changes) trans.Rollback();
        //            trans.Commit();
        //        }
        //    }
        //}

        //public void Dispose()
        //{
        //    if (_dataContext != null)
        //    {
        //        _dataContext.Dispose();
        //        GC.SuppressFinalize(false);
        //    }
        //}

        //public DbContext DbContext
        //{
        //    get
        //    {
        //        return this._dataContext;
        //    }
        //}

        private DbContext _dbContext = new DataContext();

        public DbContext DbContext
        {
            get { return _dbContext; }
        }

        //public void RegisterAdd<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot
        //{
        //    if (entity == null) throw new ArgumentNullException();
        //    EntityState state = _dbContext.Entry<TEntity>(entity).State;
        //    if(state==EntityState.Detached)
        //        _dbContext.Entry<TEntity>(entity).State = EntityState.Added;
        //}

        //public void RegisterRemove<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot
        //{
        //    if (entity == null) throw new ArgumentNullException();
        //    _dbContext.Entry<TEntity>(entity).State = EntityState.Deleted;
        //}

        //public void RgisterSave<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot
        //{
        //    if (entity == null) throw new ArgumentNullException();
        //    EntityState state = _dbContext.Entry<TEntity>(entity).State;
        //    if (state == EntityState.Detached)
        //        _dbContext.Set<TEntity>().Attach(entity);
        //    _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
        //}

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void RollBack()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(it => it.State = EntityState.Unchanged);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }

    //internal class UnitItem
    //{
    //    public IAggregateRoot Entity { get; set; }
    //    public IUnitOfWorkRepository UnitOfWorkRepository { get; set; }
    //    public UnitOperator Operator { get; set; }
    //}

    //internal enum UnitOperator
    //{
    //    Add, Save, Del
    //}
}

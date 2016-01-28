using ERP.Infrastructure;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public abstract class EFRepository<TEntity, Tld> : IRepository<TEntity, Tld> where TEntity : EntityBase, IAggregateRoot
    {
        //protected IEFUnitOfWork _efUnitOfWork = null;

        //public EFRepository() { }

        //public EFRepository(IUnitOfWork efUnitOfWork)
        //{
        //    if(efUnitOfWork==null) throw new ArgumentNullException();
        //    if (!(efUnitOfWork is IEFUnitOfWork)) throw new ArgumentException();
        //    this._efUnitOfWork = (IEFUnitOfWork)efUnitOfWork;
        //}

        //public virtual void PersistAdd(IAggregateRoot entity)
        //{
        //    if (entity == null) throw new ArgumentNullException();
        //    _efUnitOfWork.DbContext.Entry<IAggregateRoot>((T)entity).State = EntityState.Added;
        //}

        //public virtual void PersistRemove(IAggregateRoot entity)
        //{
        //    if (entity == null) throw new ArgumentNullException();
        //    _efUnitOfWork.DbContext.Entry<IAggregateRoot>((T)entity).State = EntityState.Deleted;
        //}

        //public virtual void PersistSave(IAggregateRoot entity)
        //{
        //    if (entity == null) throw new ArgumentNullException();
        //    _efUnitOfWork.DbContext.Entry<IAggregateRoot>((T)entity).State = EntityState.Modified;
        //}

        //public virtual void Add(T entity)
        //{
        //    if (entity == null) return;
        //    _efUnitOfWork.RegisterAdd(entity, this);
        //}

        //public virtual void Remove(T entity)
        //{
        //    if (entity == null) return;
        //    if (_efUnitOfWork.DbContext.Entry<T>(entity).State!=EntityState.Unchanged)
        //        _efUnitOfWork.DbContext.Set<T>().Attach(entity);
        //    _efUnitOfWork.RegisterRemove(entity, this);
        //}

        //public virtual void Save(T entity)
        //{
        //    if (entity == null) return;
        //    _efUnitOfWork.RegisterSave(entity, this);
        //}

        //public IQueryable<T> GetAll()
        //{
        //    return _efUnitOfWork.DbContext.Set<T>() as IQueryable<T>;
        //}

        //public IUnitOfWork UnitOfWork
        //{
        //    get
        //    {
        //        return (IUnitOfWork)_efUnitOfWork;
        //    }
        //    set
        //    {
        //        if (value is IEFUnitOfWork)
        //            this._efUnitOfWork = (IEFUnitOfWork)value;
        //        else
        //            throw new ArgumentException();
        //    }
        //}

        protected IEFUnitOfWork _unitOfWork = null;

        public void Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException();
            EntityState state = _unitOfWork.DbContext.Entry<TEntity>(entity).State;
            if (state == EntityState.Detached)
                _unitOfWork.DbContext.Entry<TEntity>(entity).State = EntityState.Added;
        }

        public void Remove(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException();
            EntityState state = _unitOfWork.DbContext.Entry<TEntity>(entity).State;
            if (state == EntityState.Detached)
                _unitOfWork.DbContext.Set<TEntity>().Attach(entity);
            _unitOfWork.DbContext.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public void Remove(Tld t)
        {
            TEntity entity = _unitOfWork.DbContext.Set<TEntity>().Find(t);
            if (entity == null) throw new ArgumentNullException();
            _unitOfWork.DbContext.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public void Save(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException();
            _unitOfWork.DbContext.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return (IUnitOfWork)_unitOfWork;
            }
            set
            {
                if (value is IEFUnitOfWork)
                    this._unitOfWork = (IEFUnitOfWork)value;
                else
                    throw new ArgumentException();
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return _unitOfWork.DbContext.Set<TEntity>();
        }

        public TEntity GetByKey(Tld key)
        {
            return _unitOfWork.DbContext.Set<TEntity>().Find(key);
        }
    }
}

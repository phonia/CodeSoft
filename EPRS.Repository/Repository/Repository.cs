using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EPRS.Repository
{
    public abstract class EFRepository<TEntity, Tld> : IRepository<TEntity, Tld> where TEntity : EntityBase, IAggregateRoot
    {
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

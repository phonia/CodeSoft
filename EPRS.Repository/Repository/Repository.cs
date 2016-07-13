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

        public void RemoveNonCascaded(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException();
            EntityState state = _unitOfWork.DbContext.Entry<TEntity>(entity).State;
            if (state == EntityState.Detached)
                _unitOfWork.DbContext.Set<TEntity>().Attach(entity);
            _unitOfWork.DbContext.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public void RemoveNonCascaded(Tld t)
        {
            TEntity entity = _unitOfWork.DbContext.Set<TEntity>().Find(t);
            if (entity == null) throw new ArgumentNullException();
            _unitOfWork.DbContext.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public virtual void RemoveCascaded(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveCascaded(Tld t)
        {
            throw new NotImplementedException();
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

        public IQueryable<TEntity> GetAllWithNavigationalProperty(params String[] includes)
        {
            if (includes == null)
                return GetAll();
            switch (includes.Count())
            {
                case 0: return GetAll();
                case 1: return GetAll().Include(includes[0]);
                case 2: return GetAll().Include(includes[0]).Include(includes[1]);
                case 3: return GetAll().Include(includes[0]).Include(includes[1]).Include(includes[2]);
                case 4: return GetAll().Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]);
                case 5: return GetAll().Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).Include(includes[4]);
                case 6: return GetAll().Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).Include(includes[4]).Include(includes[5]);
                case 7: return GetAll().Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).Include(includes[4]).Include(includes[5]).Include(includes[6]);
                case 8: return GetAll().Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).Include(includes[4]).Include(includes[5]).Include(includes[6]).Include(includes[7]);
                case 9: return GetAll().Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).Include(includes[4]).Include(includes[5]).Include(includes[6]).Include(includes[7]).Include(includes[8]);
                default: throw new Exception("too much navigational property!");
            }
        }
    }
}

using ERP.Infrastructure;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public abstract class Repository<T, Tld> : IUnitOfWorkRepository where T : class,IAggregateRoot
    {
        private IUnitOfWork _unitOfWork = null;
        protected DbContext _dbContext = null;

        public Repository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Repository(IUnitOfWork unitOfWork, DbContext dbContex)
        {
            this._dbContext = dbContex;
            this._unitOfWork = unitOfWork;
        }

        public void Save(T entity)
        {
            _unitOfWork.RegisterSave(this, entity);
        }

        public void Add(T entity)
        {
            _unitOfWork.RegisterAdd(this, entity);
        }

        public void Remove(T entity)
        {
            _unitOfWork.RegisterRemove(this, entity);
        }

        public virtual void PersistAdd(IAggregateRoot entity)
        {
            if (entity == null) throw new Exception("nullable data in PersistAdd of Respository<" + typeof(T).Name + ">");
            _dbContext.Entry<IAggregateRoot>(entity).State = EntityState.Added;
            if (_dbContext.SaveChanges() < 1)
            {
                throw new Exception("error in PersistAdd of Respository<T>");
            }
        }

        public virtual void PersistRemvoe(IAggregateRoot entity)
        {
            if (entity == null) throw new Exception("nullable data in PersistDel of Respository<" + typeof(T).Name + ">");
            _dbContext.Entry<IAggregateRoot>(entity).State = EntityState.Deleted;
            if (_dbContext.SaveChanges() < 1)
                throw new Exception("error in PersistDel of Respository<T>");
        }

        public virtual void PersistSave(IAggregateRoot entity)
        {
            if (entity == null) throw new Exception("nullable data in PersistSave of Respository<" + typeof(T).Name + ">");
            _dbContext.Entry<IAggregateRoot>(entity).State = EntityState.Modified;
            if (_dbContext.SaveChanges() < 1)
                throw new Exception("error in PersistSave of Respository<T>");
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>() as IQueryable<T>;
        }
    }
}

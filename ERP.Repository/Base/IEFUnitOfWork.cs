using ERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public interface IEFUnitOfWork:IUnitOfWork
    {
        DbContext DbContext { get; }

        //void RegisterAdd<TEntity>(TEntity entity) where TEntity:class, IAggregateRoot;

        //void RegisterRemove<TEntity>(TEntity entity) where TEntity :class, IAggregateRoot;

        //void RgisterSave<TEntity>(TEntity entity) where TEntity :class, IAggregateRoot;
    }
}

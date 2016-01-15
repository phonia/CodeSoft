using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Infrastructure
{
    public interface IRepository<T>:IReadOnlyRepository<T> where T:IAggregateRoot
    {
        void Add(T entity);
        void Remvoe(T entity);
        void Save(T entity);
    }
}

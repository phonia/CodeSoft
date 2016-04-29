using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public interface IReadOnlyRepository<T,Tld> where T:IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; set; }
        IQueryable<T> GetAll();
        T GetByKey(Tld key);
    }
}

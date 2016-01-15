using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Infrastructure
{
    public interface IReadOnlyRepository<T> where T:IAggregateRoot
    {
        IQueryable<T> GetAll();
    }
}

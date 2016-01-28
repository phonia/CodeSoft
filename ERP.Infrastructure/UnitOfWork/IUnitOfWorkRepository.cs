using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Infrastructure
{
    public interface IUnitOfWorkRepository
    {
        void PersistAdd(IAggregateRoot enity);
        void PersistRemove(IAggregateRoot entity);
        void PersistSave(IAggregateRoot entity);
    }
}

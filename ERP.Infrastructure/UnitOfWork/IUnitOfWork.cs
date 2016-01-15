using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Infrastructure
{
    public interface IUnitOfWork
    {
        void RegisterAdd(IUnitOfWorkRepository unitOfWork, IAggregateRoot entity);
        void RegisterRemove(IUnitOfWorkRepository unitOfWork, IAggregateRoot entity);
        void RegisterSave(IUnitOfWorkRepository unitOfWork, IAggregateRoot entity);
        void Commit();
    }
}

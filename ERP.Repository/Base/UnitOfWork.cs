using ERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        public void RegisterAdd(IUnitOfWorkRepository unitOfWork, IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public void RegisterRemove(IUnitOfWorkRepository unitOfWork, IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public void RegisterSave(IUnitOfWorkRepository unitOfWork, IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}

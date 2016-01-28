using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Infrastructure
{
    public interface IUnitOfWork:IDisposable
    {
        //void RegisterAdd(IAggregateRoot entity,IUnitOfWorkRepository unitOfWorkRepository);
        //void RegisterRemove(IAggregateRoot entity,IUnitOfWorkRepository unitOfWorkRepository);
        //void RegisterSave(IAggregateRoot entity,IUnitOfWorkRepository unitOfWorkRepository);
        //void Commit();
        int Commit();
        void RollBack();
    }
}

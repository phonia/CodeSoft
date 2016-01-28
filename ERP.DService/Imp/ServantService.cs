using ERP.Infrastructure;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.DService
{
    public class ServantService
    {
        private IUnitOfWork _unitOfWork = null;

        [InjectionConstructor]
        public ServantService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public virtual void RegisterDepartment()
        { }

        public virtual void RemoveDepartment()
        { }

        public virtual void GetAllDepartment()
        { }

        public virtual void RegisterEmployee()
        { }

        public virtual void RemoveEmployee()
        { }

        public virtual void GetAllEmployee()
        { }

        public virtual void GetAllEmployeeByDepartment()
        { }

        public virtual void GetEmployee()
        { }
    }
}

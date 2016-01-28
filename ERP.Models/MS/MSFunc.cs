using ERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Models
{
    public partial class MSFunc:EntityBase,IAggregateRoot
    {
        protected override void Validate()
        {

        }
    }

    //public interface IMSFuncRepository : IRepository<MSFunc>
    //{ }
}

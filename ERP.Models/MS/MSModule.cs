using ERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Models
{
    public partial class MSModule:EntityBase,IAggregateRoot
    {
        protected override void Validate()
        {

        }
    }

    public interface IMSModuleRepository : IReadOnlyRepository<MSModule,String>
    { }
}

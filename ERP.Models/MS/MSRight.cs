using ERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Models
{
    public partial class MSRight:EntityBase,IAggregateRoot
    {
        protected override void Validate()
        {

        }
    }

    public interface IMSRightRepository : IReadOnlyRepository<MSRight,System.Guid>
    {
 
    }
}

using ERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Models
{
    public partial class MSDomain:EntityBase,IAggregateRoot
    {
        protected override void Validate()
        {

        }
    }

    public interface IMSDomainRepository : IReadOnlyRepository<MSDomain, String>
    { }
}

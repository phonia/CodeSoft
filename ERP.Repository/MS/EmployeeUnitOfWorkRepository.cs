﻿using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class EmployeeUnitOfWorkRepository:EFRepository<Employee,System.Guid>,IEmployeeRepository
    {
    }
}

using Northwndarchitect.API.Entities;
using Northwndarchitect.CORE.BusinesModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwndarchitect.CORE.Abstractions.Operations
{
    public interface IEmployeeOperations
    {
        IEnumerable<EmployeeViewModel> GetEmployees();
        public Employee GetEmpId(int id);
    }
}

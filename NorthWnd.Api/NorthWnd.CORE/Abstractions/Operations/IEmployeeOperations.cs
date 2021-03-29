using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.Entities;
using System.Collections.Generic;

namespace NorthWnd.CORE.Abstractions.Operations
{
    public interface IEmployeeOperations
    {
        IEnumerable<EmployeeViewModel> GetAll();

        EmployeeViewModel Get(int id);

        void Remove(int id);

        Employee Add(EmployeeViewModel model);

        Employee Edit(EmployeeViewModel model);
    }
}

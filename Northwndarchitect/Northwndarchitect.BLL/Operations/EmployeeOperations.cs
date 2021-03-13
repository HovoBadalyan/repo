using Northwndarchitect.API.Entities;
using Northwndarchitect.CORE.Abstractions.Operations;
using Northwndarchitect.CORE.BusinesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwndarchitect.BLL.Operations
{
    public class EmployeeOperations : IEmployeeOperations
    {
        private readonly NORTHWNDContext context;
        public EmployeeOperations(NORTHWNDContext _context)
        {
            context = _context;
        }


        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            var data = context.Employees.ToList();
            var res = data.Select(x => new EmployeeViewModel
            {
                EmployeeId=x.EmployeeId,
                Address=x.Address,
                City=x.City,
                Country=x.Country,
                FirstName=x.FirstName,
                HomePhone=x.HomePhone,
                LastName=x.LastName,
                PostalCode=x.PostalCode,
                Region=x.Region,
                Title=x.Title,
                TitleOfCourtesy=x.TitleOfCourtesy
            });
            return res;
        }
        public Employee GetEmpId(int id)
        {
            var res=context.Employees.Find(id);
            return res;
        }
    }
}

using Microsoft.Extensions.Logging;
using NorthWnd.CORE.Abstractions;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.Entities;
using NorthWnd.CORE.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace NorthWnd.BLL.Operations
{
    public class EmployeeOperations : IEmployeeOperations
    {
        private readonly IRepositoryManager repository;
        private readonly ILogger<EmployeeOperations> logger;
        public EmployeeOperations(IRepositoryManager manager, ILogger<EmployeeOperations> _logger)
        {
            logger = _logger;
            repository = manager;
        }


        
        public Employee Add(EmployeeViewModel model)
        {
            logger.LogInformation("EmployeeOperations --- Add method started");

            Employee employee = new Employee
            {
                Address = model.Address,
                BirthDate = model.BirthDate,
                City = model.City,
                Country = model.Country,
                Extension = model.Extension,
                FirstName = model.FirstName,
                HireDate = model.HireDate,
                HomePhone = model.HomePhone,
                LastName = model.LastName,
                Notes = model.Notes,
                PostalCode = model.PostalCode,
                Region = model.Region,
                Title = model.Title,
                TitleOfCourtesy = model.TitleOfCourtesy

            };
            repository.Employees.Add(employee);
            repository.SaveChanges();

            logger.LogInformation("EmployeeOperations --- Add method finished");

            return employee;
        }


        
        public Employee Edit(EmployeeViewModel model)
        {
            logger.LogInformation("EmployeeOperations --- Edit method started");

            Employee employee = new Employee
            {
                EmployeeId = model.EmployeeId
            };
            employee.Address = model.Address;
            employee.BirthDate = model.BirthDate;
            employee.City = model.City;
            employee.Country = model.Country;
            employee.Extension = model.Extension;
            employee.FirstName = model.FirstName;
            employee.HireDate = model.HireDate;
            employee.HomePhone = model.HomePhone;
            employee.LastName = model.LastName;
            employee.Notes = model.Notes;
            employee.PostalCode = model.PostalCode;
            employee.Region = model.Region;
            employee.Title = model.Title;
            employee.TitleOfCourtesy = model.TitleOfCourtesy;

            repository.Employees.Update(employee);
            repository.SaveChanges();

            logger.LogInformation("EmployeeOperations --- Edit method finished");

            return employee;
        }


        
        public EmployeeViewModel Get(int id)
        {
            logger.LogInformation("EmployeeOperations --- Get method started");

            var result = repository.Employees.Get(id) ?? throw new LogicException("Wrong Employee ID");

            logger.LogInformation("EmployeeOperations --- Get method finished");

            return new EmployeeViewModel
            {
                Address = result.Address,
                BirthDate = result.BirthDate,
                City = result.City,
                Country = result.Country,
                EmployeeId = result.EmployeeId,
                Extension = result.Extension,
                FirstName = result.FirstName,
                HireDate = result.HireDate,
                HomePhone = result.HomePhone,
                LastName = result.LastName,
                Notes = result.Notes,
                PostalCode = result.PostalCode,
                Region = result.Region,
                Title = result.Title,
                TitleOfCourtesy = result.TitleOfCourtesy

            };
        }


        
        public IEnumerable<EmployeeViewModel> GetAll()
        {
            logger.LogInformation("EmployeeOperations --- GetAll method started");

            var data = repository.Employees.GetAll();
            var result = data.Select(x => new EmployeeViewModel
            {
                Address = x.Address,
                BirthDate = x.BirthDate,
                City = x.City,
                Country = x.Country,
                EmployeeId = x.EmployeeId,
                Extension = x.Extension,
                FirstName = x.FirstName,
                HireDate = x.HireDate,
                HomePhone = x.HomePhone,
                LastName = x.LastName,
                Notes = x.Notes,
                PostalCode = x.PostalCode,
                Region = x.Region,
                Title = x.Title,
                TitleOfCourtesy = x.TitleOfCourtesy
            });

            logger.LogInformation("EmployeeOperations --- GetAll method finished");

            return result;
        }


        
        public void Remove(int id)
        {
            logger.LogInformation("EmployeeOperations --- Remove method started");

            var res = repository.Employees.Get(id);
            repository.Employees.Remove(res);
            repository.SaveChanges();

            logger.LogInformation("EmployeeOperations --- Remove method finished");
        }
    }
}

using NorthWnd.CORE.Abstractions.Repository;
using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NorthWnd.DAL.Repositories
{
    public class CustomerRepository:RepositoryBase <Customer>,ICustomerRepository
    {
        public CustomerRepository(NORTHWNDContext context):base(context)
        {}


        //21
        public IEnumerable<TotalCustomers> GetTotalCustomers()
        {
            var query = (from customer in Context.Customers
                         group customer by new { customer.City, customer.Country } into g
                         select new TotalCustomers
                         {
                             Country = g.Key.Country,
                             City = g.Key.City,
                             Totalcustomers = g.Count()
                         }).OrderByDescending(x => x.Totalcustomers);
            return query.ToList();
        }





        //24
        public IEnumerable<CustomerListbyRegion> GetCustomerlistbyregions()
        {
            var query = from customer in Context.Customers
                        orderby customer.Region, customer.CustomerId
                        select new CustomerListbyRegion
                        {
                            CustomerId=customer.CustomerId,
                            CompanyName=customer.CompanyName,
                            Region=customer.Region
                        };
            return query.ToList();
        }


        //30
        public IEnumerable<CustomerswithOrders> GetCustomerswithnoorders()
        {
            var query = from customer in Context.Customers
                        join order in Context.Orders
                            on customer.CustomerId equals order.CustomerId into g
                        from or in g.DefaultIfEmpty()
                        where or.CustomerId==null
                        select new CustomerswithOrders
                        {
                            Cutomers_Customerid = customer.CustomerId,
                            Orders_Customerid = or.CustomerId
                        };
            return query.ToList();
        }


        //31
        public IEnumerable<Customerswithnoordersforempid4> Get4s()
        {
            var customerIds = (from order in Context.Orders
                               where order.EmployeeId == 4
                               select order.CustomerId).ToList();
            var query = from customer in Context.Customers
                        where !customerIds.Contains(customer.CustomerId)
                        select new Customerswithnoordersforempid4
                        {
                            CustomerId = customer.CustomerId,
                        };
            return query.ToList();
        }


        //32
        public IEnumerable<HighValueCustomers> GetHighvaluecustomers()
        {
            var query = (from customer in Context.Customers
                         join order in Context.Orders on customer.CustomerId equals order.CustomerId
                         where order.OrderDate.Value.Year == 1998
                         join orddet in Context.OrderDetails on order.OrderId equals orddet.OrderId
                         group orddet by new { customer.CustomerId, customer.CompanyName, order.OrderId } into g
                         where g.Sum(x => x.Quantity * x.UnitPrice) > 10000
                         select new HighValueCustomers
                         {
                             CompanyName = g.Key.CompanyName,
                             CustomerId = g.Key.CustomerId,
                             OrderId = g.Key.OrderId,
                             OrderIdTotalOrderAmount = g.Sum(x => x.Quantity * x.UnitPrice)
                         }).OrderByDescending(x => x.OrderIdTotalOrderAmount);
            return query.ToList();
        }


        //33
        public IEnumerable<HighValueCustomers> Highvaluecustomerstotalorders()
        {
            var query = (from customer in Context.Customers
                         join order in Context.Orders on customer.CustomerId equals order.CustomerId
                         where order.OrderDate.Value.Year >= 1998
                         join orddet in Context.OrderDetails on order.OrderId equals orddet.OrderId
                         group orddet by new { customer.CustomerId, customer.CompanyName, order.OrderId } into g
                         where g.Sum(x => x.Quantity * x.UnitPrice) >= 15000
                         select new HighValueCustomers
                         {
                             CompanyName = g.Key.CompanyName,
                             CustomerId = g.Key.CustomerId,
                             OrderIdTotalOrderAmount = g.Sum(x => x.Quantity * x.UnitPrice)
                         }).OrderByDescending(x => x.OrderIdTotalOrderAmount);
            return query.ToList();
        }


        //34
        public IEnumerable<HighValueCustomerswithdiscount> GetHighvaluecustomerswithdiscounts()
        {
            var query = from customer in Context.Customers
                         join order in Context.Orders on customer.CustomerId equals order.CustomerId
                         where order.OrderDate.Value.Year >= 1994
                         join orddet in Context.OrderDetails on order.OrderId equals orddet.OrderId
                         group orddet by new { customer.CustomerId, customer.CompanyName, order.OrderId } into g
                         where g.Sum(x => x.Quantity * x.UnitPrice*(decimal)(1-x.Discount)) > 10000
                         select new HighValueCustomerswithdiscount
                         {
                             CompanyName = g.Key.CompanyName,
                             CustomerId = g.Key.CustomerId,
                             TotalWithoutDiscount= g.Sum(x => x.Quantity * x.UnitPrice),
                             TotalsWithtDiscount = g.Sum(x => x.Quantity * x.UnitPrice * (decimal)(1 - x.Discount))
                         };
            return query.ToList();
        }

    }
}

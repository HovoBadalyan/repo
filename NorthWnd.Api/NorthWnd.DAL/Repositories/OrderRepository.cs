using NorthWnd.CORE.Abstractions.Repository;
using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NorthWnd.DAL.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(NORTHWNDContext dbContext)
            : base(dbContext)
        {
        }


        //27
        public IEnumerable<HighFreightOrders> GetHighfreight1996_1997()
        {
            var query = (from order in Context.Orders
                         where order.OrderDate.Value.Year > 1997
                         where order.OrderDate.Value.Year < 1998
                         group order by order.ShipCountry into g
                         select new HighFreightOrders
                         {
                             ShipCountry = g.Key,
                             AverageFreight = g.Average(x => x.Freight)
                         }).OrderByDescending(x => x.AverageFreight).Take(3);
            return query.ToList();
        }

        //25
        public IEnumerable<HighFreightOrders> GetHighfreightorders()
        {
            var query = (from order in Context.Orders
                         group order by order.ShipCountry into g
                         select new HighFreightOrders
                         {
                             ShipCountry = g.Key,
                             AverageFreight = g.Average(x => x.Freight)
                         }).OrderByDescending(x => x.AverageFreight).Take(3);
            return query.ToList();
        }


        //26
        public IEnumerable<HighFreightOrders> GetHighfreightorders1996()
        {
            var query = (from order in Context.Orders
                         where order.OrderDate.Value.Year == 1997
                         group order by order.ShipCountry into g
                         select new HighFreightOrders
                         {
                             ShipCountry = g.Key,
                             AverageFreight = g.Average(x => x.Freight)
                         }).OrderByDescending(x => x.AverageFreight).Take(3);
            return query.ToList();
        }


        //29
        public IEnumerable<InventoryListModel> GetInventoryList()
        {
            
            var query = from order in Context.Orders
                        join employee in Context.Employees on order.EmployeeId equals employee.EmployeeId
                        join orderDetail in Context.OrderDetails on order.OrderId equals orderDetail.OrderId
                        join product in Context.Products on orderDetail.ProductId equals product.ProductId
                        orderby order.OrderId, product.ProductId
                        select new InventoryListModel
                        {
                            EmployeeId = employee.EmployeeId,
                            LastName = employee.LastName,
                            OrderId = order.OrderId,
                            ProductName = product.ProductName,
                            Quantity = orderDetail.Quantity
                        };

            return query.ToList();         
        }


        //35
        public IEnumerable<MonthEndOrders> GetMonthendorders()
        {
            var query = from order in Context.Orders
                        where order.OrderDate.HasValue &&
                        order.OrderDate.Value.AddDays(1).Month > order.OrderDate.Value.Month
                        orderby order.EmployeeId, order.OrderId
                        select new MonthEndOrders
                        {
                            OrderId = order.OrderId,
                            EmployeeID = order.EmployeeId,
                            OrderDate = order.OrderDate
                        };
            return query.ToList();
        }





        //36
        public IEnumerable<OrdersWithManyLineItems> GetOrderswithmanylineitems()
        {
            var query = (from ord in Context.Orders
                         join oddet in Context.OrderDetails
                         on ord.OrderId equals oddet.OrderId
                         group ord by ord.OrderId into g
                         select new OrdersWithManyLineItems
                         {
                             OrderId = g.Key,
                             TotalOrderDetails = g.Count()
                         }).OrderByDescending(x => x.TotalOrderDetails).Take(10);
            return query.ToArray();
        }




        //37
        public IEnumerable<OrdersRandomAssortment> GetOrdersrandomassortments()
        {
            var sum = (from od in Context.Orders
                       select od).Count();

            var query = (from ord in Context.Orders
                         select new OrdersRandomAssortment
                         {
                             OrderId = ord.OrderId
                         }).Take(2 * sum / 100).OrderBy(x => x.OrderId);
            return query.ToList();

        }



        //41
        public IEnumerable<LateOrders> GetLateOrders()
        {
           
            var query = from order in Context.Orders
                        where order.ShippedDate > order.RequiredDate
                        select new LateOrders
                        {
                            OrderId = order.OrderId,
                            OrderDate = order.OrderDate,
                            RequiredDate = order.RequiredDate,
                            ShippedDate = order.ShippedDate
                        };

            return query.ToList();
        }



        //42
        public IEnumerable<LateOrdersWhichEmployees> whichEmployees()
        {
            
            var query = (from order in Context.Orders
                         join emp in Context.Employees
                         on order.EmployeeId equals emp.EmployeeId
                         where order.ShippedDate >= order.RequiredDate
                         group new { order, emp }
                         by new { order.EmployeeId, emp.LastName } into g
                         select new LateOrdersWhichEmployees
                         {
                             EmployeeId = g.Key.EmployeeId,
                             LastName = g.Key.LastName,
                             TotalLateOrders =g.Count()

                         }).OrderByDescending(x => x.TotalLateOrders);

            return query.ToList();
        }

    }
}

using Microsoft.EntityFrameworkCore;
using NLayerArchitecure.Core.Abstractions.Repositories;
using NLayerArchitecure.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NLayerArchitecure.Core.BusinessModels;

namespace NLayerArchitecure.DAL.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(NORTHWNDContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<InventoryListModel> GetInventoryList()
        {

            //36
            //var query = (from ord in Context.Orders
            //            join oddet in Context.OrderDetails
            //            on ord.OrderId equals oddet.OrderId
            //            group ord by ord.OrderId into g
            //            select new InventoryListModel
            //            {
            //                OrderId=g.Key,
            //                TotalLatOrders=g.Count()
            //            }).Take(10).OrderByDescending(x=>x.TotalLatOrders);
            //return query.ToArray();


            //37
            //var sum = (from od in Context.Orders
            //           select od).Count();

            //var query = (from ord in Context.Orders
            //            select new InventoryListModel
            //            {
            //                OrderId=ord.OrderId
            //            }).Take( 2 / sum * 100).OrderBy(x=>x.OrderId);
            //return query.ToList();


            //38
            //var query = from orddet in Context.OrderDetails
            //            where orddet.Quantity >= 60
            //            group orddet by new { orddet.OrderId, orddet.Quantity } into g 
            //            where g.Count()>1
            //            select new InventoryListModel
            //            {
            //                OrderId=g.Key.OrderId
            //            };
            //return query.ToList();


            //41
            //var query = from order in Context.Orders
            //            where order.ShippedDate > order.RequiredDate
            //            select new InventoryListModel
            //            {
            //                OrderId=order.OrderId,
            //                OrderDate=order.OrderDate,
            //                RequiredDate=order.RequiredDate,
            //                ShippedDate=order.ShippedDate
            //            };

            //return query.ToList();

            //42
            var query = (from order in Context.Orders
                         join emp in Context.Employees
                         on order.EmployeeId equals emp.EmployeeId
                         where order.ShippedDate >= order.RequiredDate
                         group new { order, emp }
                         by new { order.EmployeeId, emp.LastName } into g
                         let empid = g.FirstOrDefault().order.EmployeeId
                         let lastname = g.FirstOrDefault().emp.LastName
                         select new InventoryListModel
                         {
                             EmployeeId = empid,
                             LastName = lastname,
                             TotalLatOrders = g.Count(),

                         }).OrderByDescending(x => x.TotalLatOrders);

            return query.ToList();



        }
    }
}

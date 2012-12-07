using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Data;
using Northwind.Web.Models;
using System.Web.Http;

namespace Northwind.Web.Api
{
    /// <summary>
    /// This is the controller that gets loaded when the orders page is loaded
    /// </summary>
    public class OrdersController : BaseApiController
    {
        /// <summary>
        /// The selector used to transform <see cref="Order"/> to <see cref="OrderModel"/>
        /// </summary>
        Func<Order, OrderModel> selector = o => new OrderModel
                                                   {
                                                       Id = o.Id,
                                                       CustomerName = o.Customer.Name,
                                                       EmployeeName = o.Employee.FirstName + " " + o.Employee.LastName,
                                                       Date = o.OrderDate,
                                                       RequiredDate = o.RequiredDate,
                                                       Shipped = o.ShippedDate.HasValue,
                                                       ShippedDate = o.ShippedDate,
                                                       Details = o.Details.Select(d => new OrderDetailModel
                                                                            {
                                                                                ProductName = d.Product.Name,
                                                                                UnitPrice = d.UnitPrice,
                                                                                Quantity = d.Quantity,
                                                                                Discount = d.Discount
                                                                            }),
                                                    };
        /// <summary>
        /// Get all the orders
        /// </summary>
        /// <returns></returns>
        [Queryable]
        public IQueryable<OrderModel> Get()
        {
            return this.DataContext.Orders
                                   .Select(selector)
                                   .AsQueryable();
        }

        /// <summary>
        /// Get a single order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderModel Get(int id)
        {
            var order = this.DataContext.Orders
                                   .Select(selector)
                                   .SingleOrDefault(o => o.Id == id);

            if (order == null)
            {
                throw new HttpResponseException(new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.NotFound));
            }

            //order.Details = this.DataContext.OrderDetails
            //                                .Where(d => d.OrderId == id)
            //                                .Select(d => new OrderDetailModel
            //                                {
            //                                    ProductName = d.Product.Name,
            //                                    UnitPrice = d.UnitPrice,
            //                                    Quantity = d.Quantity,
            //                                    Discount = d.Discount
            //                                });
            return order;
        }
    }
}

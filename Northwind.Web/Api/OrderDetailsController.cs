using System.Collections.Generic;
using System.Linq;
using Northwind.Web.Models;
using System.Web.Http;

namespace Northwind.Web.Api
{
    /// <summary>
    /// This controller is loaded when the order details page is loaded
    /// </summary>
    public class OrderDetailsController : BaseApiController
    {
        /// <summary>
        /// Get the details for a specific order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Queryable]
        public IQueryable<OrderDetailModel> Get(int id)
        {
            return this.DataContext.OrderDetails
                            .Where(d => d.OrderId == id)
                            .Select(d => new OrderDetailModel
                            {
                                ProductName = d.Product.Name,
                                UnitPrice = d.UnitPrice,
                                Quantity = d.Quantity,
                                Discount = d.Discount
                            });
        }
    }
}

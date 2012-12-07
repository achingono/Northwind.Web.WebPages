using System.Linq;
using Northwind.Web.Models;

namespace Northwind.Web.Api
{
    /// <summary>
    /// This is the controller that gets called when the home page is loaded
    /// </summary>
    public class SummaryController: BaseApiController
    {
        /// <summary>
        /// Get the summarized totals of data in the system
        /// </summary>
        /// <returns></returns>
        public SummaryModel Get()
        {
            return new SummaryModel
            {
                Employees = this.DataContext.Employees.Count(),
                Customers = this.DataContext.Customers.Count(),
                Suppliers = this.DataContext.Suppliers.Count(),
                Products = this.DataContext.Products.Count(),
                Orders = this.DataContext.Orders.Count(),
            };
        }
    }
}
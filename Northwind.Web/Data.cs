using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Data;
using System.Web;

namespace Northwind.Web
{
    /// <summary>
    /// Provides access to the data collections
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// 
        /// </summary>
        private const string CONTEXT_KEY = "Northwind.Web.Data.Context";
        
        /// <summary>
        /// 
        /// </summary>
        private static NorthwindContext Context
        {
            get
            {
                NorthwindContext context = HttpContext.Current.Items[CONTEXT_KEY] as NorthwindContext;
                if (context == null)
                {
                    context = new NorthwindContext();
                    HttpContext.Current.Items[CONTEXT_KEY] = context;
                }
                return context;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static IQueryable<Category> Categories
        {
            get
            {
                return Data.Context.Categories;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static IQueryable<Customer> Customers
        {
            get
            {
                return Data.Context.Customers;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static IQueryable<Employee> Employees
        {
            get
            {
                return Data.Context.Employees;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static IQueryable<OrderDetail> OrderDetails
        {
            get
            {
                return Data.Context.OrderDetails;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static IQueryable<Order> Orders
        {
            get
            {
                return Data.Context.Orders;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static IQueryable<Product> Products
        {
            get
            {
                return Data.Context.Products;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static IQueryable<Shipper> Shippers
        {
            get
            {
                return Data.Context.Shippers;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static IQueryable<Supplier> Suppliers
        {
            get
            {
                return Data.Context.Suppliers;
            }
        }
    }
}

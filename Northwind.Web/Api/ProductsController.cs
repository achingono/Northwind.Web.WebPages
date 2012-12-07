using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Data;
using Northwind.Web.Models;
using System.Web.Http;

namespace Northwind.Web.Api
{
    /// <summary>
    /// This controller is loaded when the products page is loaded
    /// </summary>
    public class ProductsController : BaseApiController
    {
        /// <summary>
        /// The selector used to transform <see cref="Product"/> to <see cref="ProductModel"/>
        /// </summary>
        Func<Product, ProductModel> selector = p => new ProductModel
        {
            Id = p.Id,
            Name = p.Name,
            Category = p.CategoryId.HasValue ? p.Category.Name : null,
            Supplier = p.SupplierId.HasValue ? p.Supplier.Name : null,
            UnitPrice = p.UnitPrice,
            UnitsInStock = p.UnitsInStock
        };

        /// <summary>
        /// Get all products in the system
        /// </summary>
        /// <returns></returns>
        [Queryable]
        public IEnumerable<ProductModel> Get()
        {
            return this.DataContext.Products.Select(selector);
        }

        /// <summary>
        /// Get a single product with matching id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductModel Get(int id)
        {
            return this.DataContext.Products
                                   .Select(selector)
                                   .SingleOrDefault(p => p.Id == id);
        }
    }
}

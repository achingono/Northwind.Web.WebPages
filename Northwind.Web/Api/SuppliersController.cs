using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Data;
using Northwind.Web.Models;
using System.Web.Http;

namespace Northwind.Web.Api
{
    /// <summary>
    /// This controller is loaded when the suppliers page is loaded
    /// </summary>
    public class SuppliersController : BaseApiController
    {
        /// <summary>
        /// Get all the Suppliers
        /// </summary>
        /// <returns></returns>
        [Queryable]
        public IQueryable<SupplierListModel> Get()
        {
            return this.DataContext.Suppliers
                                   .Select(c => new SupplierListModel
                                   {
                                       Id = c.Id,
                                       Name = c.Name,
                                       ContactName = c.Contact.Name,
                                       ContactTitle = c.Contact.Title,
                                   });
        }

        /// <summary>
        /// Get a specific supplier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SupplierDetailModel Get(int id)
        {
            return this.DataContext.Suppliers
                                   .Select(c => new SupplierDetailModel
                                    {
                                        Id = c.Id,
                                        Name = c.Name,
                                        ContactName = c.Contact.Name,
                                        ContactTitle = c.Contact.Title,
                                        Address = c.Address,
                                        City = c.City,
                                        Region = c.Region,
                                        PostalCode = c.PostalCode,
                                        Country = c.Country,
                                        Phone = c.Phone,
                                        Fax = c.Fax,
                                    })
                                   .SingleOrDefault(c => c.Id == id);
        }
    }
}

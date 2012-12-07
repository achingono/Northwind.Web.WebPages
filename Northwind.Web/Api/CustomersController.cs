using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Data;
using Northwind.Web.Models;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace Northwind.Web.Api
{
    /// <summary>
    /// This is the controller that gets called when the customers page is loaded
    /// </summary>
    public class CustomersController : BaseApiController
    {
        /// <summary>
        /// Get all the customers
        /// </summary>
        /// <returns></returns>
        [Queryable]
        public IQueryable<CustomerListModel> Get()
        {
            return this.DataContext.Customers
                                   .Select(c => new CustomerListModel
                                   {
                                       Id = c.Id,
                                       Name = c.Name,
                                       ContactName = c.Contact.Name,
                                       ContactTitle = c.Contact.Title,
                                   });
        }

        /// <summary>
        /// Get an individual customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerDetailModel Get(string id)
        {
            return this.DataContext.Customers
                                   .Select(c => new CustomerDetailModel
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

        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="model"></param>
        public HttpResponseMessage Post(CustomerDetailModel model)
        {
            var customer = this.DataContext.Customers.Add(new Customer
            {
                Id = model.Id,
                Name = model.Name,
                Contact = new Contact
                {
                    Name = model.ContactName,
                    Title = model.ContactTitle,
                },
                Address = model.Address,
                City = model.City,
                Region = model.Region,
                PostalCode = model.PostalCode,
                Country = model.Country,
                Phone = model.Phone,
                Fax = model.Fax,
            });
            this.DataContext.SaveChanges();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, customer);
            response.Headers.Location = new Uri(Url.Link("Api", new { controller = "Customers", id = customer.Id }));
            return response;
        }

        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="model"></param>
        public HttpResponseMessage Put(CustomerDetailModel model)
        {
            var customer = this.DataContext.Customers.Find(model.Id);

            if (customer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            customer.Name = model.Name;
            customer.Contact = new Contact
            {
                Name = model.ContactName,
                Title = model.ContactTitle,
            };
            customer.Address = model.Address;
            customer.City = model.City;
            customer.Region = model.Region;
            customer.PostalCode = model.PostalCode;
            customer.Country = model.Country;
            customer.Phone = model.Phone;
            customer.Fax = model.Fax;
            this.DataContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="id"></param>
        public HttpResponseMessage Delete(string id)
        {
            var customer = this.DataContext.Customers.Find(id);

            if (customer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this.DataContext.Customers.Remove(customer);
            this.DataContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
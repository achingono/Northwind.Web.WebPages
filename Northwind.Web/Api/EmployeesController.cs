using System.Collections.Generic;
using System.Linq;
using Northwind.Web.Models;
using System.Web.Http;
using System.Net.Http;
using Northwind.Data;
using System.Net;
using System;

namespace Northwind.Web.Api
{
    /// <summary>
    /// This is the controller that gets called when the employees page is loaded
    /// </summary>
    public class EmployeesController : BaseApiController
    {
        /// <summary>
        /// Get all the employees
        /// </summary>
        /// <returns></returns>
        [Queryable]
        public IQueryable<EmployeeListModel> Get()
        {
            return this.DataContext.Employees
                                   .Select(e => new EmployeeListModel
                                                {
                                                    Id = e.Id,
                                                    FirstName = e.FirstName,
                                                    LastName = e.LastName,
                                                    Title = e.Title,
                                                    HireDate = e.HireDate,
                                                    Orders = e.Orders.Count(),
                                                });
        }

        /// <summary>
        /// Get a single employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeDetailModel Get(int id)
        {
            return this.DataContext.Employees
                                   .Select(e => new EmployeeDetailModel
                                    {
                                        Id = e.Id,
                                        FirstName = e.FirstName,
                                        LastName = e.LastName,
                                        Title = e.Title,
                                        HireDate = e.HireDate,
                                        Address = e.Address,
                                        City = e.City,
                                        Region = e.Region,
                                        PostalCode = e.PostalCode,
                                        Country = e.Country,
                                        HomePhone = e.HomePhone,
                                        Extension = e.Extension,
                                        Notes = e.Notes,
                                        ManagerId = e.ReportsTo,
                                        Manager = e.ReportsTo.HasValue ? e.Manager.FirstName + " " + e.Manager.LastName : null,
                                    })
                                   .SingleOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Create a new employee
        /// </summary>
        /// <param name="model"></param>
        public HttpResponseMessage Post(EmployeeDetailModel model)
        {
            var employee = this.DataContext.Employees.Add(new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Title = model.Title,
                HireDate = model.HireDate,
                Address = model.Address,
                City = model.City,
                Region = model.Region,
                PostalCode = model.PostalCode,
                Country = model.Country,
                HomePhone = model.HomePhone,
                Extension = model.Extension,
                Notes = model.Notes,
                ReportsTo = model.ManagerId,
                //Manager = model.ReportsTo.HasValue ? model.Manager.FirstName + " " + e.Manager.LastName : null,
            });
            this.DataContext.SaveChanges();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, employee);
            response.Headers.Location = new Uri(Url.Link("Api", new { controller = "Employees", id = employee.Id }));
            return response;
        }

        /// <summary>
        /// Update an existing employee
        /// </summary>
        /// <param name="model"></param>
        public HttpResponseMessage Put(EmployeeDetailModel model)
        {
            var employee = this.DataContext.Employees.Find(model.Id);

            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.Title = model.Title;
            employee.HireDate = model.HireDate;
            employee.Address = model.Address;
            employee.City = model.City;
            employee.Region = model.Region;
            employee.PostalCode = model.PostalCode;
            employee.Country = model.Country;
            employee.HomePhone = model.HomePhone;
            employee.Extension = model.Extension;
            employee.Notes = model.Notes;
            employee.ReportsTo = model.ManagerId;
            this.DataContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Delete a employee
        /// </summary>
        /// <param name="id"></param>
        public HttpResponseMessage Delete(int id)
        {
            var employee = this.DataContext.Employees.Find(id);

            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this.DataContext.Employees.Remove(employee);
            this.DataContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
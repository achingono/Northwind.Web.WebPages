using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Web.Models
{
    /// <summary>
    /// The UI representation of the <see cref="Northwind.Data.Order"/>
    /// </summary>
    public class OrderModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? Date { get; set; }

        [Editable(true),
        DataType(DataType.Date)]
        public DateTime? RequiredDate { get; set; }

        [Editable(true),
        DataType("checkbox")]
        public bool Shipped { get; set; }

        [Editable(true),
        DataType(DataType.Date)]
        public DateTime? ShippedDate { get; set; }
        
        public IEnumerable Details { get; set; }
        
        public decimal Total
        {
            get
            {
                return (this.Details as IEnumerable<OrderDetailModel>).Sum(d => d.Total);
            }
        }
    }
}

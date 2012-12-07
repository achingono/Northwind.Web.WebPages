using System;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Web.Models
{
    /// <summary>
    /// The UI representation of the <see cref="Northwind.Data.OrderDetail"/>
    /// </summary>
    public class OrderDetailModel
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        [Editable(true),
        DataType(DataType.Currency)]
        public float Discount { get; set; }
        
        public decimal Total
        {
            get
            {
                var total = Convert.ToDouble(this.UnitPrice * this.Quantity);
                return Convert.ToDecimal(total - (total * this.Discount));
            }
        }
    }
}

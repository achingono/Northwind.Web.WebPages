using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Data
{
    [Table("Order Details")]
    public class OrderDetail
    {
        [Key]
        [Column("Order ID", Order = 0)]
        public int OrderId { get; set; }

        [Key]
        [Column("Product ID", Order = 1)]
        public int ProductId { get; set; }

        [Column("Unit Price")]
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}

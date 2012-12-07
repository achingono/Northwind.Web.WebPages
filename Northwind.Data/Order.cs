using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Data
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [Column("Order ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [Column("Customer ID")]
        [MaxLength(5)]
        public string CustomerId { get; set; }
        
        [Column("Employee ID")]
        public int? EmployeeId { get; set; }

        public virtual Ship Ship { get; set; }

        [Column("Order Date")]
        public DateTime? OrderDate { get; set; }
        
        [Column("Required Date")]
        public DateTime? RequiredDate { get; set; }
        
        [Column("Shipped Date")]
        public DateTime? ShippedDate { get; set; }
        
        public decimal? Freight { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public virtual ICollection<OrderDetail> Details { get; set; }
    }
}

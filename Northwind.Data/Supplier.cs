using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Data
{
    [Table("Suppliers")]
    public class Supplier
    {
        [Key]
        [Column("Supplier ID")]
        public int Id { get; set; }

        [Required]
        [Column("Company Name")]
        [MaxLength(40)]
        public string Name { get; set; }

        public virtual Contact Contact { get; set; }

        [MaxLength(60)]
        public string Address { get; set; }

        [MaxLength(15)]
        public string City { get; set; }

        [MaxLength(15)]
        public string Region { get; set; }

        [Column("Postal Code")]
        [MaxLength(60)]
        public string PostalCode { get; set; }

        [MaxLength(15)]
        public string Country { get; set; }

        [MaxLength(24)]
        public string Phone { get; set; }

        [MaxLength(24)]
        public string Fax { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

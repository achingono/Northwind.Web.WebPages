using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Data
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [Column("Employee ID")]
        public int Id { get; set; }

        [Required]
        [Column("Last Name")]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [Column("First Name")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }

        [Column("Birth Date")]
        public DateTime? BirthDate { get; set; }

        [Column("Hire Date")]
        public DateTime? HireDate { get; set; }

        [MaxLength(60)]
        public string Address { get; set; }

        [MaxLength(15)]
        public string City { get; set; }

        [MaxLength(15)]
        public string Region { get; set; }

        [Column("Postal Code")]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        [MaxLength(15)]
        public string Country { get; set; }

        [Column("Home Phone")]
        [MaxLength(24)]
        public string HomePhone { get; set; }

        [MaxLength(4)]
        public string Extension { get; set; }

        public byte[] Photo { get; set; }
        
        public string Notes { get; set; }
        
        [Column("Reports To")]
        public int? ReportsTo { get; set; }

        [ForeignKey("ReportsTo")]
        public Employee Manager { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
 
    }
}

namespace Northwind.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// TODO: Update Summary
    /// </summary>
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Column("Category ID")]
        public int Id { get; set; }

        [Required]
        [Column("Category Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

namespace Northwind.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// TODO: Update Summary
    /// </summary>
    public class Contact
    {
        [Column("Contact Name")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Column("Contact Title")]
        [MaxLength(30)]
        public string Title { get; set; }
    }
}
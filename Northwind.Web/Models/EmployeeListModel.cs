using System;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Web.Models
{
    /// <summary>
    /// The UI representation of the <see cref="Northwind.Data.Employee"/>
    /// </summary>
    public class EmployeeListModel
    {
        public int Id { get; set; }

        [Editable(true),
        DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Editable(true),
        DataType(DataType.Text)]
        public string LastName { get; set; }

        [Editable(true),
        DataType(DataType.Text)]
        public string Title { get; set; }

        [Editable(true),
        DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }

        public int Orders { get; set; }
    }
}

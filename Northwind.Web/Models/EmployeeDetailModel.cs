using System.ComponentModel.DataAnnotations;
namespace Northwind.Web.Models
{
    /// <summary>
    /// The UI representation of the <see cref="Northwind.Data.Employee"/>
    /// </summary>
    public class EmployeeDetailModel: EmployeeListModel
    {
        [Editable(true),
        DataType(DataType.Text)]
        public string Address { get; set; }

        [Editable(true),
        DataType(DataType.Text)]
        public string City { get; set; }

        [Editable(true),
        DataType(DataType.Text)]
        public string Region { get; set; }

        [Editable(true),
        DataType(DataType.Text)]
        public string PostalCode { get; set; }

        [Editable(true),
        DataType(DataType.Text)]
        public string Country { get; set; }

        [Editable(true),
        DataType(DataType.PhoneNumber)]
        public string HomePhone { get; set; }

        [Editable(true),
        DataType("number")]
        public string Extension { get; set; }

        [Editable(true),
        DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        public int? ManagerId { get; set; }

        [Editable(true),
        DataType(DataType.Text)]
        public string Manager { get; set; }
    }
}

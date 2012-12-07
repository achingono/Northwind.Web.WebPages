using System.ComponentModel.DataAnnotations;
namespace Northwind.Web.Models
{
    /// <summary>
    /// The UI representation of the <see cref="Northwind.Data.Customer"/>
    /// </summary>
    public class CustomerDetailModel : CustomerListModel
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
        public string Phone { get; set; }

        [Editable(true),
        DataType(DataType.PhoneNumber)]
        public string Fax { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
namespace Northwind.Web.Models
{
    /// <summary>
    /// The UI representation of the <see cref="Northwind.Data.Supplier"/>
    /// </summary>
    public class SupplierListModel
    {
        public int Id { get; set; }

        [Editable(true),
        DataType(DataType.Text)]
        public string Name { get; set; }

        [Editable(true),
        DataType(DataType.Text)]
        public string ContactName { get; set; }

        [Editable(true),
        DataType(DataType.Text)]
        public string ContactTitle { get; set; }
    }
}

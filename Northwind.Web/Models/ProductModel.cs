using System.ComponentModel.DataAnnotations;
namespace Northwind.Web.Models
{
    /// <summary>
    /// The UI representation of the <see cref="Product"/>
    /// </summary>
    public class ProductModel
    {
        public int Id { get; set; }

        [Editable(true),
        DataType(DataType.Text)]
        public string Name { get; set; }

        [Editable(true),
        DataType(DataType.Text)]
        public string Category { get; set; }

        [Editable(true),
        DataType(DataType.Text)]
        public string Supplier { get; set; }

        [Editable(true),
        DataType(DataType.Currency)]
        public decimal? UnitPrice { get; set; }

        [Editable(true),
        DataType("number")]
        public short? UnitsInStock { get; set; }
    }
}

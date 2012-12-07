namespace Northwind.Web.Models
{
    /// <summary>
    /// The summarized version of data in the system
    /// </summary>
    public class SummaryModel
    {
        public int Employees { get; set; }
        public int Customers { get; set; }
        public int Suppliers { get; set; }
        public int Products { get; set; }
        public int Orders { get; set; }
    }
}

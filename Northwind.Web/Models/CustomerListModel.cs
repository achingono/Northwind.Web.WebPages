using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Web.Models
{
    public class CustomerListModel
    {
        public string Id { get; set; }

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

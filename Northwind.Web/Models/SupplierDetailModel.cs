using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Web.Models
{
    public class SupplierDetailModel: SupplierListModel
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

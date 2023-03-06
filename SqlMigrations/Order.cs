using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SqlMigrations
{
    internal record Order
    {
        [Key]
        public int Id { get; set; }
           
        public string InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public double CustomerID { get; set; }

        public string? Country { get; set; }

        public Order(CsvItem a)
        {
            this.Id = a.Id;
            this.InvoiceNo = a.InvoiceNo;
            this.CustomerID = a.CustomerID;
            this.Country = a.Country;
            this.InvoiceDate= a.InvoiceDate;
        }

        public Order()
        {

        }
    }
}

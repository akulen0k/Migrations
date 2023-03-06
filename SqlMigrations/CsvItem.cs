using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SqlMigrations
{
    internal record CsvItem
    {
        [Key]
        public int Id { get; set; }
        public string InvoiceNo { get; set; }

        public string StockCode { get; set; }

        public string? Description { get; set; }

        public int Quantity { get; set; }

        public DateTime InvoiceDate { get; set; }

        public double UnitPrice { get; set; }

        public double CustomerID { get; set; }

        public string? Country { get; set; }

        public bool CheckIfValid()
        {
            InvoiceDate = InvoiceDate.ToUniversalTime();
            if (StockCode is null || StockCode == "")
                return false;
            return true;
        }
    }
}

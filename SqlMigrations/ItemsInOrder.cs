using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlMigrations
{
    internal record ItemsInOrder
    {
        public string OrderId { get; set; }

        public string StockCode { get; set; }

        public int Quality { get; set; }

        public double UnitPrice { get; set; }

        public ItemsInOrder(CsvItem a) {
            this.OrderId = a.InvoiceNo;
            this.StockCode = a.StockCode;
            this.Quality = a.Quantity;
            this.UnitPrice = a.UnitPrice;
        }
    }
}

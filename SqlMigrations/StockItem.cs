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
    internal record StockItem
    {
        [Key]
        public int Id { get; set; }
        public string StockCode { get; set; }

        public string? Description { get; set; }

        public StockItem(CsvItem a)
        {
            this.StockCode = a.StockCode;
            this.Description = a.Description;
        }
    }
}

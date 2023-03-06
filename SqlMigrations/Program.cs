using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NUnit.Framework;
using System.Formats.Asn1;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Collections.Specialized;

namespace SqlMigrations
{
    class Program
    {
        public static void Main(string[] args)
        {
            string path = "online_retail.csv";
            const int rowsPerIter = 10_000;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null,
                MissingFieldFound = null,
                IgnoreBlankLines = false,
                Delimiter = ","
            };

            /*using (var reader = new StreamReader(path)) {
                using (var csv = new CsvReader(reader, config))
                {
                    int cntId = 1;
                    while (csv.Read()) {
                        csv.ReadHeader();
                        var rawRows = new List<CsvItem>();
                        for (int i = 0; i < rowsPerIter && csv.Read(); ++i)
                        {
                            try
                            {
                                var obj = csv.GetRecord<CsvItem>();
                                Assert.AreEqual(obj?.CheckIfValid(), true);
                                obj.Id = cntId;
                                ++cntId;
                                rawRows.Add(obj);
                            }
                            catch (Exception e)
                            {
                                //Console.WriteLine(e.Message);
                            }
                        }

                        using (var db = new ApplicationContext())
                        {
                            Console.WriteLine(rawRows.Count);
                            db.CsvItems.AddRange(rawRows);
                            db.SaveChanges();
                        }
                    }
                }
            }*/

            using (var db = new ApplicationContext()) // applying migrations
            {

                db.MigrateDatabase();
            }

            using (var db = new ApplicationContext())
            {
                int id = 1;
                var mySet = new SortedSet<string>();
                for (int i = 1; i<= 1000; i++)
                {
                    int first = (i - 1) * rowsPerIter + 1;
                    int last = i * rowsPerIter;
                    var items = db.CsvItems.Select(x => x).Where(x => (first <= x.Id && x.Id <= last)).ToList();
                    var new_orders = new List<Order>();
                    foreach (var v in items)
                    {
                        if (!mySet.Contains(v.InvoiceNo))
                        {  
                            var new_order = new Order(v);
                            new_order.Id = id++;
                            mySet.Add(v.InvoiceNo);
                            new_orders.Add(new_order);
                        }
                    }
                    if (new_orders.Count() == 0)
                    {
                        break;
                    }
                    db.Orders.AddRange(new_orders);
                    db.SaveChanges();
                }
            }

            using (var db = new ApplicationContext())
            {
                int id = 1;
                var mySet = new SortedSet<string>();
                for (int i = 1; i <= 1000; i++)
                {
                    int first = (i - 1) * rowsPerIter + 1;
                    int last = i * rowsPerIter;
                    var items = db.CsvItems.Select(x => x).Where(x => (first <= x.Id && x.Id <= last)).ToList();
                    var new_orders = new List<Order>();
                    foreach (var v in items)
                    {
                        if (!mySet.Contains(v.InvoiceNo))
                        {
                            var new_order = new Order(v);
                            new_order.Id = id++;
                            mySet.Add(v.InvoiceNo);
                            new_orders.Add(new_order);
                        }
                    }
                    if (new_orders.Count() == 0)
                    {
                        break;
                    }
                    db.Orders.AddRange(new_orders);
                    db.SaveChanges();
                }
            }
        }
    }
}
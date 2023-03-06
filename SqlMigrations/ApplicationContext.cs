using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SqlMigrations
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<CsvItem> CsvItems { get; set; }
        
        public DbSet<Order> Orders { get; set; }

        //public DbSet<CsvItem> CsvItems { get; set; }

        //public DbSet<CsvItem> CsvItems { get; set; }

        public ApplicationContext()
        {

        }

        public void MigrateDatabase()
        {
            Database.Migrate();
            Database.r;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CsvItems;Username=postgres;Password=12345");
        }
    }
}

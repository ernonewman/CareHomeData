using System;
using System.Collections.Generic;
using CareHomeData.Ui.Console.Models;
using Microsoft.EntityFrameworkCore;

namespace CareHomeData.Ui.Console.DataContext
{
    public class SQLiteContext : DbContext
    {
        private readonly string _dbLocation;

        public SQLiteContext()
        {
        }

        public SQLiteContext(string dbLocation = "cqc.db")
        {
            _dbLocation = dbLocation;
        }

        public DbSet<ProviderDetail> ProviderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (string.IsNullOrWhiteSpace(_dbLocation))
            {
                options.UseSqlite("Data Source=cqc.db");
            }
            else
            {
                options.UseSqlite($"Data Source={_dbLocation}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<ProviderDetail>()
                .Property(e => e.locationIds)
                .HasConversion(
                    x => string.Join(',', x),
                    y => y.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}

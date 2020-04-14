using System;
using System.Collections.Generic;
using CQCViewer.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CQCViewer.Shared.DataContext
{
    public class SQLiteContext : DbContext
    {
        string _dbLocation;

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

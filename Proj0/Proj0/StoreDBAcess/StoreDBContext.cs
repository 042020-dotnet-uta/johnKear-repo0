using System;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using StoreDBAcess.Models;

namespace StoreDBAcess
{
	class StoreDBContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Inventory> Inventories { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderHistory> OrderHistories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<SalesHistory> SalesHistories { get; set; }

		public StoreDBContext() { }

		public StoreDBContext(DbContextOptions<StoreDBContext> options)
			: base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			if (!options.IsConfigured)
			{
				options.UseSqlite("Data Source=proj0.db");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}

	}
}

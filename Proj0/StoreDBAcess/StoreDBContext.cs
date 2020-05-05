using System;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using StoreDBAcess.Models;
using System.Linq;

namespace StoreDBAcess
{
	public class StoreDBContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<Order> Order { get; set; }
		public DbSet<OrderDetails> OrderDetails { get; set; }
		//public DbSet<OrderHistory> OrderHistories { get; set; }
		public DbSet<Product> Products { get; set; }
		//public DbSet<SalesHistory> SalesHistories { get; set; }

		public StoreDBContext() { }

		public StoreDBContext(DbContextOptions<StoreDBContext> options)
			: base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			if (!options.IsConfigured)
			{
				options.UseSqlite("Data Source=D:\\Documents\\RevatureTraining\\RevatureRepo\\johnKear-repo0\\Proj0\\Proj0\\proj0.db");
				//options.UseSqlServer("Data Source=D:\\Documents\\RevatureTraining\\RevatureRepo\\johnKear-repo0\\Proj0\\Proj0\\proj0.db");
			}
		}

		/*protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Product>(c=> { c.HasOne<>} )

			modelBuilder.Entity<Order>
				(
					o =>
					{
						o.HasOne<Location>().WithOne()
					  .HasForeignKey<Order>(e => e.LocationId);
					}
				);

		}*/

	}
}

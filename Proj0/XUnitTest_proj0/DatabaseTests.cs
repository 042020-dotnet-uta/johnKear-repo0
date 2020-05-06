using System;
using Microsoft.EntityFrameworkCore;
using StoreDBAcess;
using Xunit;
using System.Linq;
using Microsoft.Data.Sqlite;
using StoreDBAcess.Models;
using Xunit.Sdk;
using Microsoft.Extensions.Options;

namespace XUnitTest_proj0
{
	public class DatabaseTests
	{

		/// <summary>
		/// Creates a valid customer and attempts to add to db
		/// </summary>
		[Fact] //test1
		public void AddsValidCustomerToDB()
		{
			#region Arrange
			var options = new DbContextOptionsBuilder<StoreDBContext>()
				.UseInMemoryDatabase(databaseName: "AddsPlayerToDB")
				.Options;
			#endregion

			#region Act
			//Act -- Add a valid customer
			// Valid Customer has firstname, lastname, phonenumber
			using (var db = new StoreDBContext(options))
			{
				Customer c = new Customer
				{
					FName = "John",
					LName = "Kear",
					PhoneNum = "123421234"
				};

				try
				{
					db.Add(c);
					db.SaveChanges();
				}
				catch (Exception e)
				{
					System.Diagnostics.Trace.WriteLine("Failed to add customer to db with exception: ", e.Message);
				}
			}

			#endregion

			#region Assert
			//Assert
			using (var context = new StoreDBContext(options))
			{

				Assert.Equal(1, context.Customers.Count());

				var fName = context.Customers.Where(c => c.LName == "Kear").FirstOrDefault();
				Assert.Equal("John", fName.FName);

			}

			#endregion
		}

		/// <summary>
		/// Attempts to create an invalid customer
		/// </summary>
		[Fact] //test2
		public void CreateInvalidCustomer()
		{
			#region Arrange
			//Arrange -- create an object to configure in-memory DB
			var options = new DbContextOptionsBuilder<StoreDBContext>()
				.UseInMemoryDatabase(databaseName: "CreateInvalidCustomer")
				.Options;
			#endregion

			#region Act-Assert
			//Act -- try to create invalid customer
			// Valid Customer has firstname, lastname, phonenumber
			try
			{
				Customer c1 = new Customer
				{
					FName = "John",
					PhoneNum = "123421234"
				};
			}
			catch (Exception e) // An exception should be thrown 
			{
				//Assert that exception is the null exception
				Assert.Equal("Parameter cannot be null", e.Message.Trim());
			}
			#endregion

		}

		/// <summary>
		/// Creates a valid location and adds it to db
		/// </summary>
		[Fact] //test3
		public void AddLocationToDB()
		{
			#region Arrange
			string locName = "Bogo, Philippines";
			//Arrange -- create an object to configure in-memory DB
			var options = new DbContextOptionsBuilder<StoreDBContext>()
				.UseInMemoryDatabase(databaseName: "AddsLocationToDB")
				.Options;
			#endregion

			#region Act
			//Act -- create valid location and add to db
			//Vaid locations have a location name
			using (var db = new StoreDBContext(options))
			{

				Location loc = new Location
				{
					LocName = locName
				};


				try
				{
					db.Add(loc);
					db.SaveChanges();
				}
				catch (Exception e)
				{
					Console.WriteLine("Failed to add customer to db with exception: ", e);
				}

			}
			#endregion

			#region Assert
			//Assert
			using (var context = new StoreDBContext(options))
			{
				Assert.Equal(1, context.Locations.Count());

				var locationName = context.Locations.Where(c => c.LocationId == 1).FirstOrDefault();
				Assert.Equal(locName, locationName.LocName);
			}
			#endregion
		}

		/// <summary>
		/// Attempts to create an invalid Location
		/// </summary>
		[Fact] //test4
		public void CreateInvalidLocaton()
		{
			#region Arrange
			//Arrange -- create an object to configure in-memory DB
			var options = new DbContextOptionsBuilder<StoreDBContext>()
				.UseInMemoryDatabase(databaseName: "CreateInvalidLocation")
				.Options;
			#endregion

			#region Act-Assert
			//Act -- Create an invalid location
			// Valid locations have a location name
			try
			{
				Location loc = new Location();

			}
			catch (Exception e)
			{
				//Assert that exception is the null exception
				Assert.Equal("Parameter cannot be null", e.Message.Trim());
			}
			#endregion
		}

		/// <summary>
		/// Create and add a valid product to DB
		/// </summary>
		[Fact] //test5
		public void AddValidProductToDB()
		{
			#region Arrange
			//Arrange -- create an object to configure in-memory DB
			var options = new DbContextOptionsBuilder<StoreDBContext>()
				.UseInMemoryDatabase(databaseName: "AddsProductToDB")
				.Options;
			#endregion

			#region Act
			//create a Valid Order and add to DB
			//Valid Product consists of name, price, quantity
			using (var db = new StoreDBContext(options))
			{
				Product product = new Product
				{
					LocationId = 1,
					ProductName = "Mango",
					UnitCost = .75,
					Quantity = 35
				};

				db.Add(product);
				db.SaveChanges();

			}

			#endregion

			#region Assert
			using (var context = new StoreDBContext(options))
			{
				//assert than only one row exists in products table
				Assert.Equal(1, context.Products.Count());

				//assert that expected cost for item is correct
				var cost = context.Products.Where(c => c.ProductName == "Mango").FirstOrDefault();
				Assert.Equal(.75, cost.UnitCost);
			}
			#endregion
		}

		/// <summary>
		/// Attempts to create an invalid product
		/// </summary>
		[Fact] //test6
		public void CreatInvalidProduct()
		{
			#region Arrange
			//Arrange -- create an object to configure in-memory DB
			var options = new DbContextOptionsBuilder<StoreDBContext>()
				.UseInMemoryDatabase(databaseName: "CreateInvalidProduct")
				.Options;
			#endregion

			#region Act-Assert
			//Try to create invalid product
			//Valid Product consists of name, price, quantity
			try
			{
				Product product = new Product
				{
					ProductName = "Mango",
					UnitCost = 2.4
				};
			}
			catch (Exception e)
			{
				//Assert that exception is the null exception
				Assert.Equal("Parameter cannot be null", e.Message.Trim());
				Console.WriteLine("Invalid product with exception: ", e.Message);
			}
			#endregion
		}

		/// <summary>
		/// Adds Valid order to DB
		/// </summary>
		/*[Fact] //test7
		public void AddOrderToDB()
		{
			#region Arrange
			//Arrange -- create an object to configure in-memory DB
			var options = new DbContextOptionsBuilder<StoreDBContext>()
				.UseInMemoryDatabase(databaseName: "AddsPlayerToDB")
				.Options;
			#endregion

			#region Act-Assert
			#region Variables
			//customer parameters (fname, lname, phone)
			string c1fn = "John";
			string c1ln = "Kear";
			string c1p = "123-123-1234";
			string c2fn = "Bat";
			string c2ln = "man";
			string c2p = "123-312-234";

			//location parameters (name)
			string l1name = "San Francisco";
			string l2name = "New York";
			string l3name = "Philippines";

			//product parameters (name, cost, quantity)
			string p1n = "Mango";
			double p1c = 0.55;
			int p1q = 10;
			string p2n = "Nectarine";
			double p2c = 1.23;
			int p2q = 30;
			string p3n = "Pear";
			double p3c = 2.10;
			int p3q = 5;

			#endregion//end variables

			using (var db = new StoreDBContext(options))
			{
				//Create Customers, Locations, Products and add to db
				#region DBPropogation 
				Customer c1 = new Customer
				{
					FName = c1fn,
					LName = c1ln,
					PhoneNum = c1p
				};

				Customer c2 = new Customer
				{
					FName = c2fn,
					LName = c2ln,
					PhoneNum = c2p
				};

				db.Add(c1);
				db.Add(c2);

				Location l1 = new Location { LocName = l1name };
				Location l2 = new Location { LocName = l2name };
				Location l3 = new Location { LocName = l3name };

				db.Add(l1);
				db.Add(l2);
				db.Add(l3);

				Product p1 = new Product
				{
					LocationId = l1.LocationId,
					ProductName = p1n,
					UnitCost = p1c,
					Quantity = p1q
				};

				Product p2 = new Product
				{
					LocationId = l1.LocationId,
					ProductName = p2n,
					UnitCost = p2c,
					Quantity = p2q
				};

				Product p3 = new Product
				{
					LocationId = l3.LocationId,
					ProductName = p3n,
					UnitCost = p3c,
					Quantity = p3q
				};

				db.Add(p1);
				db.Add(p2);
				db.Add(p3);

				db.SaveChanges();
				#endregion

				#region AddOrder
				//valid order (Customer Id, LocationID)
				var c1id = db.Customers.Where(c => c.FName == c1fn).FirstOrDefault();
				var l1id = db.Locations.Where(c => c.LocName == l1name).FirstOrDefault();
				Order o1 = new Order
				{
					CustomerId = c1id.CustomerId,
					LocationId = l1id.LocationId
				};
				//order parameters
				Quantities o1p1qty = new Quantities();
				o1p1qty.Quantity = 7;
				Quantities o1p2qty = new Quantities();
				o1p2qty.Quantity = 15;
				Quantities o1p3qty = new Quantities();
				o1p3qty.Quantity = 2;

				//add product to order productlocation and order location must match
				if (p1.LocationId == o1.LocationId) { o1.AddProduct(p1, o1p1qty); }
				if (p2.LocationId == o1.LocationId) { o1.AddProduct(p2, o1p2qty); }
				if (p3.LocationId == o1.LocationId) { o1.AddProduct(p3, o1p3qty); }

				double total = (p1c * o1p1qty.Quantity) + (p2c * o1p2qty.Quantity);

				//add order to db
				db.Add(o1);
				//save db changes
				db.SaveChanges();

				#endregion //end add order to db

				#region Assert
				//Assert that correct number of products are in db
				var order = db.Orders.Where(o => o.CustomerId == 1).FirstOrDefault();
				Assert.Equal(2, order.Products.Count());
				//Assert product names are correct
				var prod = order.Products.Where(p => p.ProductName == p1n).FirstOrDefault();
				Assert.Equal(p1n, prod.ProductName);
				//Assert correct total is stored
				Assert.Equal(total, order.Total);
				#endregion //end assert

			}
			#endregion //end Act

		}
*/


		/// <summary>
		/// Remove order from DB
		/// </summary>
		[Fact] //test8
		public void RemoveOrderFromDB()
		{
			#region Arrange
			//Arrange -- create an object to configure in-memory DB
			var options = new DbContextOptionsBuilder<StoreDBContext>()
				.UseInMemoryDatabase(databaseName: "RemoveOrderFromDB")
				.Options;
			#endregion

			#region Act-Assert
			//Act
			using (var db = new StoreDBContext(options))
			{
				Order order = new Order
				{
					CustomerId = 1,
					LocationId = 1,
					TimeStamp = "1230",
					Total = 50
				};
				db.Add(order);
				db.SaveChanges();

				#region Assert
				Assert.Equal(1, db.Order.Count());

				db.Remove(order);
				db.SaveChanges();

				Assert.Equal(0, db.Order.Count());
				#endregion //end assert
			};
			#endregion //end act

		}

		/// <summary>
		/// Updates a Customers Preferred location
		/// </summary>
		[Fact] //test9
		public void UpdateCustPrefLoc()
		{
			//Arrange -- create an object to configure in-memory DB
			var options = new DbContextOptionsBuilder<StoreDBContext>()
				.UseInMemoryDatabase(databaseName: "UpdateCustPrefLoc")
				.Options;

			int newLoc = 10;
			//Act -- Add a valid customer
			// Valid Customer has firstname, lastname, phonenumber
			//After adding to database change the preferred location
			using (var db = new StoreDBContext(options))
			{
				Customer c = new Customer
				{
					FName = "John",
					LName = "Kear",
					PhoneNum = "123421234"
				};

				try
				{
					db.Add(c);
					db.SaveChanges();
				}
				catch (Exception e)
				{
					System.Diagnostics.Trace.WriteLine("Failed to add customer to db with exception: ", e.Message);
				}

				var cust = db.Customers.Where(c => c.FName == "John").FirstOrDefault();
				cust.PreferredLoc = newLoc;
				db.SaveChanges();
			}

			#region Assert
			using (var context = new StoreDBContext(options))
			{

				var cust = context.Customers.Where(c => c.FName == "John").FirstOrDefault();
				Assert.Equal(newLoc, cust.PreferredLoc);
			}
			#endregion

		}

		/// <summary>
		/// EMPTY!!!!
		/// </summary>
		[Fact] //test10
		public void Test10()
		{
			//Arrange -- create an object to configure in-memory DB
			var options = new DbContextOptionsBuilder<StoreDBContext>()
				.UseInMemoryDatabase(databaseName: "AddsPlayerToDB")
				.Options;

			//Act

			//Assert
		}

	}
}
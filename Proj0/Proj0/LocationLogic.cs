using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proj0
{
	class LocationLogic
	{

		/// <summary>
		/// Validates if location exists in database
		/// </summary>
		/// <param name="name"></param>
		/// <returns boolean></returns>
		public static bool ValidLocation(string name)
		{
			bool valid = false;
			var loc = StoreApp.db.Locations.Where(l => l.LocName == name).FirstOrDefault();
			if (loc != null) valid = true;
			return valid;
		}

		/// <summary>
		/// Prints sales history of specified location
		/// </summary>
		/// <param name="name"></param>
		public static void LocationSales(string name)
		{
			//Verify that location has orders
			var loc = StoreApp.db.Locations.Where(l => l.LocName == name).FirstOrDefault();
			var order = StoreApp.db.Order.Where(o => o.LocationId == loc.LocationId).ToList();
			if(order.Count() == 0) // if no orders print corresponding message
			{
				Console.WriteLine("This location has no sales. Press any key to continue.");
				Console.ReadKey();
			}
			else //print all order history for location
			{
				Console.WriteLine("Location {0} Sales:", loc.LocName);
				//Order history
				foreach (var item in order)
				{
					Console.WriteLine("--OrderId: {0}; CustomerID: {1}; TimeStamp: {2}; Total: ${3}", item.OrderId, item.CustomerId, item.TimeStamp, item.Total);
					var details = StoreApp.db.OrderDetails.Where(d => d.OrderId == item.OrderId).ToList();
					//order details
					foreach(var item1 in details)
					{
						var product = StoreApp.db.Products.Where(p => (p.ProductId == item1.ProductId) && (p.LocationId == item.LocationId)).FirstOrDefault();
						if (product != null) //this if statement shouldn't be necessary but orders were added manually
							Console.WriteLine("----OrderId: {0}; ProductId: {1}; ProductName: {2}; Quantity = {3}; UnitCost: {4}", item1.OrderId, item1.ProductId, product.ProductName, item1.Qty, product.UnitCost);
					}
				}
				Console.WriteLine("\nPress any key to continue.");
				Console.ReadKey();
			}
			
		}
	}
}

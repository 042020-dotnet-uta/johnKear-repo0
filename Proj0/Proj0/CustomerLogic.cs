using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StoreDBAcess;
using StoreDBAcess.Models;

namespace Proj0
{
	class CustomerLogic
	{

		#region CustomerMenus

		/// <summary>
		/// Displays Customer create menu
		/// </summary>
		public static void PrintCreateCustomerMenu()
		{
			Console.WriteLine("Please enter the following values\n1. First Name\n2. Last Name\n3. Phone Number\n4. Preffered Location\n5. Cancel");
		}

		/// <summary>
		/// Displays Customer Menu
		/// </summary>
		public static void PrintCustomerMenu()
		{
			Console.Clear();
			Console.WriteLine("Select an option\n1. New Order\n2. Order Details\n3. Order History\n4. Cancel");
		}

		#endregion


		/// <summary>
		/// Creates a new customer and adds to database
		/// </summary>
		public static void CreateNewCustomer()
		{
			#region Method variables
			string fname = "", lname = "", phone = "", prefloc ="";
			bool missingProperty = true;
			bool createCustomer = true;
			bool addPrefLoc = false;
			bool valid = false;
			int step = 1;
			#endregion

			#region Get all customer properties
			do
			{
				switch (step)
				{
					#region Get first name
					case 1: // get user first name
						do
						{
							
							Console.Write("Enter first name: ");
							fname = Console.ReadLine();
							valid = !(string.IsNullOrWhiteSpace(fname));
							if (!valid) { Helpers.NotValidOption(fname); }
						} while (!valid);
						step++; //go to next step
						valid = false; //reset valid
						break;
					#endregion

					#region Get last name
					case 2: // get user last name
						do
						{
							
							Console.Write("Enter last name: ");
							lname = Console.ReadLine();
							valid = !(string.IsNullOrWhiteSpace(lname));
							if (!valid) { Helpers.NotValidOption(lname); }
						} while (!valid);
						step++; //go to next step
						valid = false; //reset valid
						break;
					#endregion

					#region GetPhone
					case 3: // get phone #
						do
						{
							#region Validate user input for phone number
							Console.Write("Enter phone number in following format (Ex: 1234567890): ");
							phone = Console.ReadLine();
							valid = Helpers.IsValidPhoneNumber(phone);
							if (!valid) 
							{ 
								Helpers.NotValidOption(phone);
								continue;
							}
							#endregion

							#region Ensure unique phone number
							//Search DB for number
							var number = new Customer();
							try
							{
								number = StoreApp.db.Customers.Where(p => p.PhoneNum == phone).FirstOrDefault();
							}catch(Exception e)
							{
								Console.WriteLine("Error finding customer with number {0}, with error: {1}", phone, e);
								Console.WriteLine("Try again");
								valid = false;
							}
							finally
							{
								if (number != null)
								{
									valid = false;
									Console.Clear();
									Console.WriteLine("Customer with phone number {0} aready exits.", phone);
								}
							}
							#endregion

						} while (!valid);
						step++; //go to next step
						valid = false; //reset valid
						break;
					#endregion

					#region Get Preferred Location
					case 4: // get preferred location						
						do
						{
							Console.Write("Would you like to enter a preferred location (y or n)?: ");
							string yOrNo = Console.ReadLine();
							valid = !(string.IsNullOrWhiteSpace(yOrNo));
							if (!valid) { Helpers.NotValidOption(yOrNo); }
							if (yOrNo != "y" && yOrNo != "n")
							{
								Helpers.NotValidOption(yOrNo);
								valid = false;
							}
							else if(yOrNo == "y")
							{								
								do // get pref location and check that it exists in db
								{
									valid = false;
									Console.WriteLine("Enter preferred location or enter c to cancel preferred locaiton: ");
									prefloc = Console.ReadLine();
									valid = !(string.IsNullOrWhiteSpace(prefloc));
									if(prefloc == "c")
									{
										addPrefLoc = false;
									}
									else
									{
										var loc = new Location();
										try
										{
											loc = StoreApp.db.Locations.Where(l => l.LocName == prefloc).FirstOrDefault();
										}catch(Exception e)
										{
											Console.WriteLine("Error while finding location: {0} ", e);											
										}
										
										if (loc == null)
										{
											valid = false;
											Helpers.NotValidOption(prefloc);
										}
										else { addPrefLoc = true; }
									}
								} while (!valid);	//end check if exists in db
							}else if (yOrNo == "n")
							{
								addPrefLoc = false;
								valid = true;
							}

						} while (!valid);
						step++; //go to next step
						break;
					#endregion

					default: // ready to create customer
						missingProperty = false;
						break;
				}
			} while (missingProperty);
			#endregion

			#region Add Customer to database
			if (createCustomer && addPrefLoc)
			{
				Console.WriteLine("\nadding customer to db");
				try
				{
					Location x = StoreApp.db.Locations.Where(l =>l.LocName==prefloc).FirstOrDefault();
					Customer cust = new Customer(fname, lname, phone, x);
					StoreApp.db.Add(cust);
					StoreApp.db.SaveChanges();					
				}
				catch (Exception e)
				{
					Console.WriteLine("Error customer to database with error: ", e);
				}				
			}else if(createCustomer && !addPrefLoc)
			{
				Customer cust = new Customer(fname, lname, phone);
				StoreApp.db.Add(cust);
				StoreApp.db.SaveChanges();
			}
			#endregion
		}

		/// <summary>
		/// Determines if user exists in the database
		/// </summary>
		/// <param name="phone"></param>
		/// <returns boolean></returns>
		public static bool UserExists(string phone)
		{
			bool valid = false;
			//find if user exists in database
			var cust = StoreApp.db.Customers.Where(c => c.PhoneNum == phone).FirstOrDefault();
			if (cust != null) valid = true;
			return valid;
		}

		/// <summary>
		/// Runs customer options logic
		/// </summary>
		/// <param name="phone"></param>
		public static void CustomerOptions(string phone)
		{
			#region Method variables
			bool placeOrder = false;
			bool quit = false;
			bool end = false;
			bool valid = false;
			string location;
			string currProduct;
			int currQty = 0;
			List<(string, int)> products = new List<(string, int)>();
			#endregion

			#region Customer operations
			do
			{
				int option = Helpers.GetMenuOption(Menus.Customer);
				switch (option)
				{
					#region CASE1: Create new order
					case 1: // new order
						#region Get order details
						//order details: location, products, qty
						//get order location
						Console.Clear();
						do
						{
							quit = false;
							end = false;
							valid = false;
							Console.Write("Enter location for order or enter c to cancel: ");
							location = Console.ReadLine();
							valid = !(string.IsNullOrWhiteSpace(location));
							if(location == "c")
							{
								end = true;
								valid = true;
							}
							else if (!valid)
							{
								Helpers.NotValidOption(location);
							}else
							{
								//determine if location is in database
								var loc = StoreApp.db.Locations.Where(l => l.LocName == location).FirstOrDefault();
								if (loc == null)
								{
									Helpers.NotValidOption(location);
									valid = false;
								}
							}
						} while (!valid);
						if (end) break;
						#region Get products
						do
						{
							Console.WriteLine("Enter product name, c to cancel or p to place order: ");
							currProduct = Console.ReadLine();
							valid = !(string.IsNullOrWhiteSpace(currProduct));
							if (!valid) Helpers.NotValidOption(currProduct);
							else if (currProduct == "c")
							{
								end = true;
							}
							else if (currProduct == "p" && (currQty <= 0))
							{
								Console.WriteLine("There are no products in order.");
								end = true;
								valid = true;
								placeOrder = false;
							}
							else if (currProduct == "p")
							{
								end = true;
								valid = true;
								placeOrder = true;
							}
							else
							{
								#region Verify product is available in location 								
								var prod = StoreApp.db.Products.Where(p => p.ProductName == currProduct).FirstOrDefault();
								if (prod == null)
								{
									Helpers.NotValidOption(currProduct);
									end = false;
									valid = false;
								}
								else valid = true;
								if (!valid) continue;
								var loc = StoreApp.db.Locations.Where(l => l.LocName == location).FirstOrDefault();
								if (loc.LocationId != prod.LocationId)
								{
									Console.WriteLine("Product does not exist in this location");
								}
								else
								{
									//verify quantity is available
									//get quantity
									//validate is integer
									bool isInt = false;
									do
									{
										Console.Write("Enter quantity: ");
										string input = Console.ReadLine();
										isInt = int.TryParse(input, out currQty);
										if (isInt && (currQty < 0)) isInt = false;
									} while (!isInt);
									if (prod.Quantity < currQty)
									{
										Console.WriteLine("Not enough available product at this location.");
									}
									else if (prod.Quantity >= currQty)
									{
										bool found = false;
										foreach((string, int) it in products)
										{
											if(it.Item1 == currProduct)
											{
												Console.WriteLine("Cannot add duplicate product to order.");
												found = true;
											}
										}
										if (!found)
										{
											products.Add((currProduct, currQty));
											Console.WriteLine("Product added to order");
										}
									}
								}
								#endregion
							}	

							#endregion
						} while (!end);

						#endregion

						#region Create new order and add to database
						if (placeOrder)
						{
							Order thisOrder = new Order();
							double total = 0;
							var loc = StoreApp.db.Locations.Where(l => l.LocName == location).FirstOrDefault();
							var cust = StoreApp.db.Customers.Where(c => c.PhoneNum == phone).FirstOrDefault();
							
							foreach ((string, int) item in products)
							{
								var prod = StoreApp.db.Products.Where(p => (p.ProductName==item.Item1)&&(p.LocationId==loc.LocationId)).FirstOrDefault();
								total += (item.Item2 * prod.UnitCost);
								prod.Quantity -= item.Item2;
							}
							var max = StoreApp.db.Order.Max(o => o.OrderId);
							thisOrder.OrderId = max + 1;
							thisOrder.Total = total;
							thisOrder.LocationId = loc.LocationId;
							thisOrder.CustomerId = cust.CustomerId;
							StoreApp.db.Add(thisOrder);
							StoreApp.db.SaveChanges();
							foreach((string, int) item in products)
							{
								var prod = StoreApp.db.Products.Where(p => (p.ProductName == item.Item1) && (p.LocationId == loc.LocationId)).FirstOrDefault();
								OrderDetails details = new OrderDetails();
								details.OrderId = thisOrder.OrderId;
								details.ProductId = prod.ProductId;
								details.Qty = item.Item2;
								StoreApp.db.Add(details);
								StoreApp.db.SaveChanges();
							}
						}
						#endregion
						break;
					#endregion

					#region CASE2: Print order details
					case 2: // print order details
						end = false;
						valid = false;
						int id;
						#region Get order id and validate
						do
						{
							Console.WriteLine("Enter order ID to be displayed or c to cancel");
							string input = Console.ReadLine();
							valid = !(string.IsNullOrWhiteSpace(input));
							valid = int.TryParse(input, out id);
							if (input == "c")
							{
								end = true;
								valid = true;
								break;
							}else if (!valid)
							{
								Helpers.NotValidOption(input);
							}
							else
							{
								//check if ID is in database for given customer
								var cust = StoreApp.db.Customers.Where(c => c.PhoneNum == phone).FirstOrDefault();
								var order = StoreApp.db.Order.Where(o => (o.OrderId == id) && o.CustomerId==cust.CustomerId).FirstOrDefault();
								if (order == null)
								{
									Helpers.NotValidOption(input);
									valid = false;
								}
								else
								{
									var details = StoreApp.db.OrderDetails.FromSqlRaw("SELECT * FROM OrderDetails WHERE OrderId=={0}", id).ToList();
									Console.Clear();
									foreach(var item in details)
									{
										Console.WriteLine("OrderId: {0} ; ProductId: {1} ; Quantity: {2}", item.OrderId, item.ProductId, item.Qty);
										
									}
									Console.WriteLine("Press any key to continue.");
									Console.ReadKey();
								}
							}
							
						} while (!valid);
						if (end) break;
						#endregion


						break;
					#endregion

					#region CASE3: Print order history
					case 3: //print order history
						Console.Clear();
						var cust1 = StoreApp.db.Customers.Where(c => c.PhoneNum == phone).FirstOrDefault();
						int id1 = cust1.CustomerId;
						var history = StoreApp.db.Order.Where(o => o.CustomerId == id1).ToList();
						//var history = StoreApp.db.Order.FromSqlRaw("SELECT * FROM Order WHERE CustomerId=={0}", cust1.CustomerId).ToList();
						if (history.Count() == 0)
						{
							Console.WriteLine("You have no order history. Press any key to continue.");
							Console.ReadKey();
						}
						else
						{
							foreach(var item in history)
							{
								Console.WriteLine("OrderId: {0}; LocationId: {1}; TimeStamp: {2}; TotalCost: ${3}", item.OrderId, item.LocationId, item.TimeStamp, item.Total);
								var details1 = StoreApp.db.OrderDetails.FromSqlRaw("SELECT * FROM OrderDetails WHERE OrderId == {0}", item.OrderId).ToList();
								foreach(var item2 in details1)
								{
									var product = StoreApp.db.Products.Where(p => (p.ProductId == item2.ProductId)&&(p.LocationId==item.LocationId)).FirstOrDefault();
									if(product!=null) //this if statement shouldn't be necessary but orders were added manually
									Console.WriteLine("---OrderId: {0}; ProductId: {1}; ProductName: {2}; Quantity = {3}; UnitCost: {4}", item2.OrderId, item2.ProductId, product.ProductName, item2.Qty, product.UnitCost);
								}
							}
							Console.WriteLine("\nPress any key to continue.");
							Console.ReadKey();
						}
						break;
					#endregion

					default: //cancel
						quit = true;
						break;
				}
			} while (!quit);
			#endregion
		}

	}
}

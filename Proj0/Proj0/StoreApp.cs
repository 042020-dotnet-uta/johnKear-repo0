using StoreDBAcess;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using Microsoft.VisualBasic;

namespace Proj0
{
	class StoreApp
	{
		private int userOption;
		public static StoreDBContext db = new StoreDBContext();
		public void Run()
		{			
			bool quit = false;
			#region App Menu
			do
			{
				Console.Clear();
				Helpers.PrintWelcome();
				//Get user option
				userOption = Helpers.GetMenuOption(Menus.Start);
				switch (userOption)
				{
					#region CASE1: Login with existing user
					case 1: //login with existing user
						Console.Clear();
						bool valid = false;
						bool end = false;
						string phone;
						do
						{
							Console.Write("Enter phone number or enter c to cancel: ");
							phone = Console.ReadLine();
							if (phone == "c")
							{
								end = true;
								valid = true;
							}
							else
							{
								valid = Helpers.IsValidPhoneNumber(phone);
								if (!valid) Helpers.NotValidOption(phone);								
								var cust = db.Customers.Where(p => p.PhoneNum == phone).FirstOrDefault();
								if (cust == null)
								{
									valid = false;
									Helpers.NotValidOption(phone);
								}								
							}
						} while (!valid);
						if (end) break;
						CustomerLogic.CustomerOptions(phone);
						break;
					#endregion

					#region CASE2: Create new user
					case 2: // create new user
						Console.Clear();
						Console.WriteLine("Creating a new user");
						CustomerLogic.CreateNewCustomer();
						break;
					#endregion

					#region CASE 3: Location sales history
					case 3: //location
						valid = false;
						end = false;
						Console.Clear();
						string name1;
						#region Validate user input
						do
						{
							Console.Write("Enter location name or c to cancel: ");
							name1 = Console.ReadLine();
							valid = !(string.IsNullOrWhiteSpace(name1));
							if (name1 == "c")
							{
								valid = true;
								end = true;
							}
							else if (!valid) Helpers.NotValidOption(name1);
							else valid = LocationLogic.ValidLocation(name1);
							if (!valid) Helpers.NotValidOption(name1);
						} while (!valid);
						if (end) break;
						#endregion
						//display sales history for location
						LocationLogic.LocationSales(name1);
						break;
					#endregion

					#region CASE4: Search by name
					case 4:
						Console.Clear();
						valid = false;
						end = false;
						string name;

						#region Validate user input
						do
						{
							Console.Write("Enter customer name or c to cancel: ");
							name = Console.ReadLine();
							valid = !(string.IsNullOrWhiteSpace(name));
							if(name == "c")
							{
								valid = true;
								end = true;
							}else	if (!valid) Helpers.NotValidOption(name);
						} while (!valid);
						if (end) break;
						#endregion

						Helpers.SearchCustomer(name);
						break;
					#endregion

					default: //exit program
						quit = true;
						break;
				}				
				///usertype? customer or location

				//Display options (customer)
				///create new order
				///view order histories
				//OR Display options (location)
				///search customers by name
				///display order history of store location
			} while (!quit);
			#endregion

		}

	}

}

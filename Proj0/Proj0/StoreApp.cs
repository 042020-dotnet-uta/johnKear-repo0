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

			do
			{
				Console.Clear();
				Helpers.PrintWelcome();
				//Get user option
				userOption = Helpers.GetMenuOption(Menus.Start);
				switch (userOption)
				{
					#region Login with existing user
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
					#region Create new user
					case 2: // create new user
						Console.Clear();
						Console.WriteLine("Creating a new user");
						CustomerLogic.CreateNewCustomer();
						break;
					#endregion

					#region Location login
					case 3: //location
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
			
		}


	}

}

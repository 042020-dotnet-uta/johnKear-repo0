using StoreDBAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proj0
{
	enum Menus { Start, CreateCustomer, Customer };

	class Helpers
	{

		/// <summary>
		/// Displays Welcome message
		/// </summary>
		public static void PrintWelcome()
		{
			Console.WriteLine("Welcome to Farmer John's Store!");
		}

		#region Menus and helpers

		/// <summary>
		/// Displays start menu
		/// </summary>
		public static void PrintStartMenu()
		{
			Console.WriteLine("\n1. Login\n2. New Customer\n3. Location orders\n4. Search Customers\n5. Exit");
		}

		/// <summary>
		/// Prompts user for option from specified menu
		/// Validates user input based on menu
		/// </summary>
		/// <param name="menu"></param>
		/// <returns int>User option</returns>
		public static int GetMenuOption(Menus menu)
		{
			#region Method variables
			int choice = 0;
			bool valid = false;
			string input;
			#endregion

			#region Menus
			do
			{
				
				switch (menu)
				{
					#region Main start menu
					case Menus.Start: //Main start menu operations
						PrintStartMenu();
						input = Console.ReadLine();
						//valid = string.IsNullOrWhiteSpace(input);
						valid = int.TryParse(input, out choice);
						if (!valid)
						{
							Console.Clear();
							NotValidOption(input);
						}
						else if (choice < 1 || choice > 5)
						{
							Console.Clear();
							NotValidOption(input);
							valid = false; //ensure that valid is false
						}
						break;
					#endregion

					#region Create customer menu
					case Menus.CreateCustomer: //Create customer menu
						CustomerLogic.PrintCreateCustomerMenu();
						input = Console.ReadLine();
						valid = int.TryParse(input, out choice);
						if (!valid)
						{
							Console.Clear();
							NotValidOption(input);
						}
						else if (choice < 1 || choice > 5)
						{
							Console.Clear();
							NotValidOption(input);
							valid = false; //ensure that valid is false
						}
						break;
					#endregion

					#region Customer menu
					case Menus.Customer: //Customer menu
						CustomerLogic.PrintCustomerMenu();
						input = Console.ReadLine();
						valid = int.TryParse(input, out choice);
						if (!valid)
						{
							Console.Clear();
							NotValidOption(input);
						}
						else if (choice < 1 || choice > 4)
						{
							Console.Clear();
							NotValidOption(input);
							valid = false; //ensure that valid is false
						}
						break;
					#endregion

				}

			} while (!valid);
			#endregion

			return choice;
		}

		/// <summary>
		/// Displays input not valid message
		/// </summary>
		/// <param name="input"></param>
		public static void NotValidOption(string input)
		{
			Console.Clear();
			Console.WriteLine($"{input} is not a valid option\n");
		}

		#endregion

		/// <summary>
		/// Validates that phone number is a 10 digit integer
		/// </summary>
		/// <param name="phone"></param>
		/// <returns boolean></returns>
		public static bool IsValidPhoneNumber(string phone)
		{
			bool valid = false;
			try
			{
				valid = !(string.IsNullOrWhiteSpace(phone));
				bool isNum = int.TryParse(phone, out _);
				if (isNum && (phone.Length == 10)) valid = true;
				else valid = false;
			}catch(Exception e)
			{
				Console.WriteLine("Error validating phone number with exception: {0}", e);
				valid = false;
			}		
			
			return valid;
		}

		public static void SearchCustomer(string name)
		{
			var cust = StoreApp.db.Customers.Where(c => c.FName == name).ToList();
			if(cust.Count() == 0)
			{
				Console.WriteLine("No customer found by this name {0}. Press any key to continue", name);
				Console.ReadKey();
			}
			else
			{
				foreach(var item in cust)
				{
					Console.WriteLine("Customer found:customerId= {0}, firstname= {1}, lastname= {2}, phonenumber= {3}, preferred locationId= {4}", item.CustomerId, item.FName, item.LName, item.PhoneNum, item.PreferredLoc);
				}
				Console.WriteLine("\nPress any key to continue.");
				Console.ReadKey();
			}

		}

	}



}

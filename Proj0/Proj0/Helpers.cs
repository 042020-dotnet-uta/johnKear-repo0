using StoreDBAcess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proj0
{
	enum Menus { Start, Customer };

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
			Console.WriteLine("\n1. Login\n2. New Customer\n3. Location Login\n4. Exit");
		}

		
		/// <summary>
		/// Prompts user for option from specified menu
		/// Validates user input based on menu
		/// </summary>
		/// <param name="menu"></param>
		/// <returns int>User option</returns>
		public static int GetMenuOption(Menus menu)
		{
			int choice = 0;
			bool valid = false;
			string input;
			do
			{
				
				switch (menu)
				{
					case Menus.Start:
						PrintStartMenu();
						input = Console.ReadLine();
						//valid = string.IsNullOrWhiteSpace(input);
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
					case Menus.Customer:
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
					
				}
				
			} while (!valid);

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

		#region Database Methods
		

		#endregion
	}



}

using StoreDBAcess;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;

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
					case 1: //login with existing user
						break;
					case 2: // create new user
						Console.Clear();
						Console.WriteLine("Creating a new user");
						CustomerLogic.CreateNewCustomer();
						break;
					case 3: //location
						break;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StoreDBAcess;
using StoreDBAcess.Models;

namespace Proj0
{
	class CustomerLogic
	{

		/// <summary>
		/// Displays Customer create menu
		/// </summary>
		public static void PrintCreateCustomerMenu()
		{
			Console.WriteLine("Please enter the following values\n1. First Name\n2. Last Name\n3. Phone Number\n4. Preffered Location\n5. Cancel");
		}

		/// <summary>
		/// Creates a new customer and adds to database
		/// </summary>
		public static void CreateNewCustomer()
		{
			string fname = "", lname = "", phone = "", prefloc ="";
			bool missingProperty = true;
			bool createCustomer = true;
			bool addPrefLoc = false;
			bool valid = false;
			int step = 1;

			do
			{
				switch (step)
				{
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
					case 3: // get phone #
						do
						{
							
							Console.Write("Enter phone number in following format (Ex: 1234567890): ");
							phone = Console.ReadLine();
							valid = !(string.IsNullOrWhiteSpace(phone));
							bool isNum = int.TryParse(phone, out _);
							if (!valid)
							{
								Helpers.NotValidOption(phone);
							}
							else if(!isNum)
							{
								Helpers.NotValidOption(phone);
								valid = false;
							}
						} while (!valid);
						step++; //go to next step
						valid = false; //reset valid
						break;
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
					default: // ready to create customer
						missingProperty = false;
						break;
				}
			} while (missingProperty);

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

		}

	}
}

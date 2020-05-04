using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Transactions;

namespace CodingChallenge2
{
	class Helpers
	{
		/// <summary>
		/// Displays menu choices
		/// Validates user choice
		/// Returns user choice
		/// </summary>
		/// <returns>int userchoice</returns>
		public static int MenuChoice()
		{
			
			bool valid = false;
			int choice;
			
			do
			{
				Console.WriteLine("Select an option:\n1. Check if number is even\n2. Print multiplication table of number\n3. Shuffle\n4. Exit");
				string input = Console.ReadLine();
				valid = int.TryParse(input, out choice);
				if (!valid) 
				{
					Console.WriteLine($"{input} is not a valid option."); 
				}else if (choice < 1 || choice > 4)
				{ 
					valid = false;
					Console.WriteLine($"{input} is not a valid option.");
				}
			} while (!valid);

			return choice;
		}

		/// <summary>
		/// Gets number input from user
		/// Validates user input is a number
		/// Determines if user input is even
		/// Displays message accordingly
		/// </summary>
		public static void IsEven()
		{
			double x = 0;
			bool isNumber = false;
			//prompt user for integer input

			do
			{
				Console.Write("Please enter a number: ");
				string input = Console.ReadLine();
				//validate input
				isNumber = double.TryParse(input, out x);
				if (!isNumber)
				{
					Console.WriteLine($"{input} is a string, not a number: ");
				}
			} while (!isNumber);
			
			// determine if number is even
			if((x%2) == 0){
				// if even print is even message
				Console.WriteLine($"{x} is an even number.\n");
			}
			else
			{
				//if not even print not even message
				Console.WriteLine($"{x} is not an even number.\n");
			}
			
		}// end is even

		/// <summary>
		/// Gets integer from user
		/// Validates user input
		/// Calculates and displays multiplication table for user input
		/// </summary>
		public static void MultTable()
		{
			int x;
			//get user inputbool 
			bool isInt = false;
			
			//prompt user for integer input
			do
			{
				Console.Write("Please enter a number: ");
				string input = Console.ReadLine();
				//validate input
				isInt = int.TryParse(input, out x);
				if (!isInt)
				{
					Console.WriteLine($"{input} is a string, not a number: ");
				}
			} while (!isInt);

			//generate mult table up to the input value
			int n1 = 1;
			int n2 = 1;
			while(n1 <= x)
			{
				Console.WriteLine("{0} * {1} = {2}", n1, n2, n1 * n2);
				if(n1 <= x && n2 == x) { n2 = 1;
					n1++;
				}
				else { n2++; }
			}
			Console.WriteLine("");
		}

		/// <summary>
		/// Prompts user for two lists of five elements each
		/// Validates user input correct number of elements
		/// Joins two lists into single list alternating between list elements
		/// Displays joined list
		/// </summary>
		public static void Suffle()
		{
			
			string[] firstList;
			string[] secondList;
			
			//get two lists of five elements each from the user.
			Console.WriteLine("Enter two lists of five elements each with each element separated by a space");
			do
			{
				Console.WriteLine("Enter first list:");
				string input = Console.ReadLine();
				input.Trim();
				firstList = input.Split(' '); //parse user input into list
				if(firstList.Count() != 5) { Console.WriteLine("Incorrect number of elements for list one"); } //if user did not input 5 elements display error message
			} while (firstList.Count() != 5);
			do
			{
				Console.WriteLine("Enter second list:");
				string input = Console.ReadLine();
				input.Trim();
				secondList = input.Split(' '); //parse user input into list
				if (secondList.Count() != 5) { Console.WriteLine("Incorrect number of elements for list one"); } //if user did not input 5 elements display error message
			} while (secondList.Count() != 5);

			// join two lists while alternating between list elements
			List<string> shuffled = new List<string>();
			for (int i = 0; i <= secondList.Length - 1; i++ ){
				try
				{
					shuffled.Add(firstList[i]);
					shuffled.Add(secondList[i]);
				}catch(Exception e)
				{
					Console.WriteLine("Could not add element to list with error: ", e);
				}
				
			}

			//display new list to console
			foreach(string e in shuffled)
			{
				Console.Write(e + " ");
			}

			Console.WriteLine("\n");
		}
	}
}

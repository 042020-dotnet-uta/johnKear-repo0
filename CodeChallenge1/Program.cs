/*John Kear
 * 
 * Print all the numbers starting from 1 to 100.  
When the number is multiple of three, print “sweet” instead of a number on the console.
If the number is a multiple of five then print “salty” on the console.
For numbers which are multiples of three and five, print “sweet’nSalty” on the console.
At the end, tell how many sweet’s, how many salty’s, and how many sweet’nSalty’s
Comment enough to tell me what each line is doing, and site your sources.*/

using System;
using System.Runtime.CompilerServices;

namespace CodeChallenge1
{
	class Program
	{
		static void Main(string[] args)
		{
			// integer variables for sweet, salty, and sweetnsalty counts
			int sweet = 0, salty = 0, sweetnsalty = 0;

			#region PrintNumbers
			//iterate through integers 1 through 100
			for (int i = 1; i <= 100; i++)
			{
				if(IsMultOfThree(i) && IsMultOfFive(i)) //if number is multiple of three and five increment sweetnsalty and print "sweet'nSalty" to console
				{
					sweetnsalty++;
					Console.WriteLine("sweet'nSalty");
				}else if (IsMultOfThree(i)) //if number is just a multiple of three increment sweet and print "sweet" to console
				{
					sweet++;
					Console.WriteLine("sweet"); 
				}else if (IsMultOfFive(i)) //if number is just a multiple of five increment salty and print "salty" to console
				{
					salty++;
					Console.WriteLine("salty");
				}
				else //if number is neither multiple of five or three just print the number to console
				{
					Console.WriteLine(i);
				}
			}//end for
			#endregion

			#region PrintFinalResults
			//print the number of sweet, salty, and sweet'nSalty
			Console.WriteLine($"The number of sweet is: {sweet}\nThe number of salty is: {salty}\nThe number of sweet'nSalty is: {sweetnsalty}");
			#endregion
		}

		static public bool IsMultOfThree(int x)
		{
			//check if parameter is multiple of three
			//using modulus operator, check if the remainder of x/3 is equal to zero.
			//if the remainder is zero, the number is a multiple of 3
			return (x % 3) == 0;
		}

		static public bool IsMultOfFive(int x)
		{
			//check if parameter is multiple of five
			//using modulus operator, check if the remainder of x/5 is equal to zero.
			//if the remainder is zero, the number is a multiple of 5
			return (x % 5) == 0;
		}
	}
}

using System;
using System.Drawing;
using System.Linq;

namespace predicateLambda
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = { 5, 10, 2, 1 };
			var roots = numbers.Select(x => Math.Sqrt(x));
			Console.WriteLine(string.Join(" ", roots));
		}
	}
}

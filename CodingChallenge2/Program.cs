using System;

namespace CodingChallenge2
{
	class Program
	{

		static void Main(string[] args)
		{
			#region Properties
			bool exit = false;
			#endregion

			#region RunProg
			//run program until user selects to exit
			do
			{
				int choice = Helpers.MenuChoice();
				switch (choice)
				{
					case 1: //menu item 1 (is even)
						Helpers.IsEven();
						break;
					case 2: //menu item 2 (mult table)
						Helpers.MultTable();
						break;
					case 3: //menu item 3 (shuffle)
						Helpers.Suffle();
						break;
					default: //menu item 4 (exit)
						exit = true;
						break;
				}					
			} while (!exit);
			#endregion
		}
	}
}

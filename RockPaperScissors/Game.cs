using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
	class Game
	{
		private List<Round> round;

		public Player p1 { get; set; }
		public Player p2 { get; set; }

		public void Run()
		{
			Random rng= new Random();

			//Get player information
			this.p1 = Player.FromConsole(1);
			this.p2 = Player.FromConsole(2);

			int p1Wins = 0;
			int p2Wins = 0;

			do
			{

			} while ();
		}

	}
}

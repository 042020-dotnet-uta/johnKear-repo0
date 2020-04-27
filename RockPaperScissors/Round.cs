using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
	class Round
	{
		public string winner { get; set; }
		public Choice p1Choice, p2Choice;
		public Player p1, p2;
	}

	public Round(Player p1, Player p2, Random rng)
	{
		this.p1 = p1;
		this.p2 = p2;
		this.p1Choice = (Choice)rng.Next(3);
		this.p2Choice = (Choice)rng.Next(3);
		this.result = Round.DetermineWinner();
	}
}

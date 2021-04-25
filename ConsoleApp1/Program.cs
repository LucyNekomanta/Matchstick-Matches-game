using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Aufgabe_7__NIMM_DREI__Dennis_Nicolai
{
	class Program
	{
		static int MatchsticksNumber,MaxDraw;

		static void Main(string[] args)
		{
			Console.Write("Instructions:{0}" +
				"There are at least 12 or a maximum of 1000 matches on an imaginary table.{0}" +
				"Each player must take at least one , or a maximum of 100 matches per turn.{0}" +
				"Whichever player takes the last stick looses the game.{0}",
									Environment.NewLine);
			Console.Write("Please enter the number of max matchsticks on the table: ");

			bool testcheck=false;
			while (!testcheck)
			{
				MatchsticksNumber = NumCheckFunction(1000);
				if(MatchsticksNumber>=12)
				{
					testcheck=true;
				}
				else
				{
					Console.WriteLine("Your Number is to low, you have to pick at least 12.");
				}
			}
			testcheck=false;
						Console.Write("Please enter the number of max matches to take{0}"+
				"Be aware, it has to be maximum "+ MatchsticksNumber/4 +"!: ",
					Environment.NewLine);
			while(!testcheck)
			{
				MaxDraw=NumCheckFunction(100);
			if(MaxDraw <= (MatchsticksNumber/4))
				{
					testcheck=true;
					PlayerSelect();
				}
			else
				{
					Console.WriteLine("You have to enter a number that is smaller than "+ MatchsticksNumber/4 +"!");
				}
			}
			testcheck=false;
			Console.WriteLine("Press any key to end");
			Console.ReadKey(true);
		}

		static void PlayerSelect()
		{
			Console.WriteLine("Do you want to play against an AI player(1) or against a human player(2)(who has to sit next to you)?{0}" +
				"Write '1' for AI player or '2' for human player.",
					Environment.NewLine);
			int helper = NumCheckFunction(2);
			bool goFirst = CoinTossFunction();
			if (helper == 2)
			{
				if (!goFirst)
				{
					Console.WriteLine("Player1 goes second");
				}
				else
				{
					Console.WriteLine("Player1 goes first");
				}
				HumanGame(goFirst);
			}
			else
			{
				if (!goFirst)
				{
					Console.WriteLine("AI goes first");
				}
				else
				{
					Console.WriteLine("AI goes second");
				}
				AIgame(goFirst);
			}


		}
		static bool CoinTossFunction()
		{
			Console.WriteLine("Now we toss a coin to decide who goes first, choose: Heads(1), or Tails(2) ?{0}" +
				"Type 1 for Heads(1) or 2 for Tails(2)",
					Environment.NewLine);
			int schroedinger = NumCheckFunction(2);
			Random rnd = new Random();
			int rndValue = rnd.Next(1, 3);
			//1 ist in der range vorhanden, 3 ist nicht das upper limit, sondern 2
			if (rndValue == schroedinger)
			{
				//goFirst = true;
				Console.WriteLine("Player1 guessed correct, he goes first.");
				return true;
			}
			else
			{
				//goFirst = false;
				Console.WriteLine("Player1 guessed incorrect, he goes second.");
				return false;
			}
		}
		static void HumanGame(bool goFirst)
		//human vs human
		{
			int drawYourLastPatheticCard;
			bool turnPlayer1=goFirst;

			while (MatchsticksNumber > 0)
			{
				ShowMatchsticksFunction();

				if (turnPlayer1)
	{
					Console.Write("Player1, choose a number from 1 to " + MaxDraw + " to take: ");
					//turnPlayer1=false;
	}
				else
	{
					Console.Write("Player2, choose a number from 1 to " + MaxDraw + " to take: ");
					//turnPlayer1=true;
	}
				drawYourLastPatheticCard = NumCheckFunction(MaxDraw);

				MatchsticksNumber = MatchsticksNumber - drawYourLastPatheticCard;

				if (MatchsticksNumber <= 0)

				{
					if (turnPlayer1)
	{
						Console.WriteLine("Player1 lost, Player2 wins the game");
	}
					else
	{
						Console.WriteLine("Player2 lost, Player1 wins the game");
	}
				}
				turnPlayer1=!turnPlayer1;
			}
		}
		static void AIgame(bool goFirst)

		{
			int drawYourLastPatheticCard;
			bool turnPlayer1=goFirst;

			while (MatchsticksNumber > 0)
			{
				ShowMatchsticksFunction();

				if(turnPlayer1)
				{
					Console.Write("Player1, choose a number from 1 to "+ MaxDraw + "to take: ");
					drawYourLastPatheticCard=NumCheckFunction(MaxDraw);
					MatchsticksNumber = MatchsticksNumber - drawYourLastPatheticCard;
				}
				else
				{
					int computerDraw;
					int bestPlay=MatchsticksNumber%(MaxDraw+1);
					if(bestPlay==0)
					{
					Random rnd = new Random();
					computerDraw = rnd.Next(1,(MaxDraw+1));
					}
					else
					{
						computerDraw=bestPlay;
						MatchsticksNumber=MatchsticksNumber-computerDraw;
						Console.WriteLine("Computer picks {0} matches", computerDraw);
					}
				}
				if (MatchsticksNumber <= 0)

				{
					if(turnPlayer1)
					{
						Console.WriteLine("Player1 lost, computer wins the game");
					}
					else
					{
						Console.WriteLine("computer lost, Player1 wins the game");
					}

				}
				turnPlayer1=!turnPlayer1;
			}
		}
		static int NumCheckFunction(int dynamicNumCheck)
		//checks if input is a number that is bigger than 0 or in range
		{
			bool numCheck=false;
			int numCheckOutput;

				while (!numCheck)
				{
					string input = Console.ReadLine();
					if (int.TryParse(input, out numCheckOutput) && numCheckOutput > 0 && numCheckOutput <= dynamicNumCheck)
					{
						numCheck = true;
						return numCheckOutput;
					}
					else
					{
						Console.WriteLine("You have to write a number that is in the range of 1 and " + dynamicNumCheck);
					}
				}
				return 0;
		}
		static void ShowMatchsticksFunction()
		//shows the number of matches in play
		{
			Console.WriteLine("There are " + MatchsticksNumber + " matches in play.");
			for (int i = 0; i < MatchsticksNumber; ++i)
			{
				Console.Write("|");
			}
			Console.WriteLine("");
		}
	}
}
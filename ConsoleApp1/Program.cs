using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Aufgabe_7__NIMM_DREI__Dennis_Nicolai
{
    class Program
    {
        static int numCheckOutput, dynamicNumCheck;
        static int MatchsticksNumber;
        static bool goFirst, enableLimitlessNumCheck;

        //static string coinToss;

        static void CoinTossFunction()
        {
            Console.WriteLine("Now we toss a coin to decide who goes first, choose: Heads(1), or Tails(2) ?{0}" +
                "Type 1 for Heads(1) or 2 for Tails(2)",
                    Environment.NewLine);
            int rndValue, schroedinger;
            enableLimitlessNumCheck = false;
            dynamicNumCheck = 2;
            NumCheckFunction();
            schroedinger = numCheckOutput;
            Random rnd = new Random();
            rndValue = rnd.Next(1, 2);
            if (rndValue == schroedinger)
            {
                goFirst = true;
                Console.WriteLine("Player1 guessed correct, he goes first.");
            }
            else
            {
                goFirst = false;
                Console.WriteLine("Player1 guessed incorrect, he goes second.");
            }
        }
        static void NumCheckFunction()
        //checks if input is a number that is bigger than 0 or in range
        {
            bool numCheck;
            numCheck = false;

            if (!enableLimitlessNumCheck)
            {
                while (!numCheck)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out numCheckOutput) && numCheckOutput > 0 && numCheckOutput <= dynamicNumCheck)
                    {
                        numCheck = true;
                    }
                    else
                    {
                        Console.WriteLine("You have to write a number that is in the range of 1 and " + dynamicNumCheck);
                    }
                }
            }
            else
            {
                while (!numCheck)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out numCheckOutput) && numCheckOutput > 0)
                    {
                        numCheck = true;
                        enableLimitlessNumCheck = false;
                    }
                    else
                    {
                        Console.WriteLine("You have to write a number that is bigger than zero.");
                    }
                }
            }
        }
        static void HumanGame()
        //human vs human
        {
            int player1, player2;
            enableLimitlessNumCheck = false;
            dynamicNumCheck = 3;

            while (MatchsticksNumber > 0)
            {
                ShowMatchsticksFunction();
                Console.Write("Player1, choose a number from 1 to 3 to take: ");
                NumCheckFunction();
                player1 = numCheckOutput;

                MatchsticksNumber = MatchsticksNumber - player1;

                if (MatchsticksNumber <= 0)

                {

                    Console.WriteLine("Player1 lost, Player2 wins the game");

                }

                else

                {
                    ShowMatchsticksFunction();
                    Console.Write("Player2, choose a number from 1 to 3 to take: ");
                    NumCheckFunction();
                    player2 = numCheckOutput;
                    MatchsticksNumber = MatchsticksNumber - player2;


                    if (MatchsticksNumber <= 0)

                    {

                        Console.WriteLine("Player2 lost, Player1 wins the game");

                    }

                }

            }
        }
        static void PlayerSelect()
        {
            Console.WriteLine("Do you want to play against an AI player(1) or against a human player(2)(who has to sit next to you)?{0}" +
                "Write '1' for AI player or '2' for human player.",
                    Environment.NewLine);
            enableLimitlessNumCheck = false;
            dynamicNumCheck = 2;
            NumCheckFunction();
            int helper = numCheckOutput;
            CoinTossFunction();
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
                HumanGame();
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
                AIgame();
            }


        }
        static void AIgame()

        {

            int player1, computer;
            int matchesTaken;
            matchesTaken = 3 + 1;

            while (MatchsticksNumber > 0)

            {
                ShowMatchsticksFunction();
                //Console.WriteLine("There are {0} matches, choose a number in the range of 1 to 3 to take.", MatchsticksNumber);

                player1 = Convert.ToInt32(Console.ReadLine());

                MatchsticksNumber = MatchsticksNumber - player1;

                if (MatchsticksNumber <= 0)

                {

                    Console.WriteLine("You Lose");

                }

                else

                {

                    computer = matchesTaken - player1;

                    Console.WriteLine("Computer picks {0} matches", computer);

                    MatchsticksNumber = MatchsticksNumber - computer;

                    if (MatchsticksNumber <= 0)

                    {
                        Console.WriteLine("You Win");
                    }
                }
            }
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
        static void Main(string[] args)
        {
            Console.Write("Instructions:{0}" +
                "There are a Number of matches on an imaginary table.{0}" +
                "Each player must take at least one , or a maximum of 3 matches per turn.{0}" +
                "Whichever player takes the last stick looses the game.{0}" +
                "Please enter the Number of Matchsticks used: ",
                    Environment.NewLine);
            enableLimitlessNumCheck = true;
            NumCheckFunction();
            MatchsticksNumber = numCheckOutput;
            PlayerSelect();

            Console.WriteLine("Press any key to end");
            Console.ReadKey(true);
        }
    }
}

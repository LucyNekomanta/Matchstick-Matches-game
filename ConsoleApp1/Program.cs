using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Aufgabe_7__NIMM_DREI__Dennis_Nicolai
{
    class Program
    {
        static int MatchsticksNumber;

        static void Main(string[] args)
        {
            Console.Write("Instructions:{0}" +
                "There are a Number of matches on an imaginary table.{0}" +
                "Each player must take at least one , or a maximum of 3 matches per turn.{0}" +
                "Whichever player takes the last stick looses the game.{0}" +
                "Please enter the Number of Matchsticks used: ",
                    Environment.NewLine);
            MatchsticksNumber = NumCheckFunction(1000);
            PlayerSelect();

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
                    Console.Write("Player1, choose a number from 1 to 3 to take: ");
                    //turnPlayer1=false;
    }
                else
    {
                    Console.Write("Player2, choose a number from 1 to 3 to take: ");
                    //turnPlayer1=true;
    }
                drawYourLastPatheticCard = NumCheckFunction(3);

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

            int player1, computer;
            int matchesTaken = 3 + 1;
            bool turnPlayer1=goFirst;

            while (MatchsticksNumber > 0)
            {
                ShowMatchsticksFunction();

                if(turnPlayer1)
                { 
                    Console.Write("Player1, choose a number from 1 to 3 to take: ");
                }
                else
                { 
                computer = matchesTaken - player1;
                    //Random rnd = new Random();
                    //int rndValue = rnd.Next(1, 4);

                    Console.WriteLine("Computer picks {0} matches", computer);

                    MatchsticksNumber = MatchsticksNumber - computer;
                }
                
                player1=NumCheckFunction(3);
                
                MatchsticksNumber = MatchsticksNumber - player1;

                if (MatchsticksNumber <= 0)

                {
                    if(turnPlayer1)
                    {
                        Console.WriteLine("Player1 lost, computer wins the game");
                    }
                    else
                    {
                        Console.WriteLine("Player2 lost, Player1 wins the game");
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

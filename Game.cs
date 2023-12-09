using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class Game
    {
        public int computerMove;
        public int playerMove;
        public int countOfMoves;
        public string result = "";

        public static void ShowMenu(string[] args)
        {
            Console.WriteLine("Aviable moves:");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(i + 1 + " - " + args[i]);
            }
            Console.WriteLine("0 - exit\n? - help");
            return;
        }

        public static void GetPlayerMove(string[] args, Game g)
        {
            Console.Write("Enter your move: ");
            string? move = Console.ReadLine();
            if (Int32.TryParse(move, out int playerMove) && playerMove >= 0 && playerMove <= args.Count())
            {
                MoveLikeNumber(args, playerMove, g);
            }
            else
            {
                MoveLikeChar(args, move, g);
            }
            return;
        }

        static void MoveLikeNumber(string[] args, int playerMove, Game g)
        {
            if (playerMove == 0)
            {
                Environment.Exit(0);
            }
            Console.WriteLine("Your move: " + args[playerMove - 1]);
            g.playerMove = playerMove - 1;
            return;
        }

        static void MoveLikeChar(string[] args, string? move, Game g)
        {
            if (move == "?")
            {
                Help h = new Help(args);
                GetPlayerMove(args, g);
            }
            else
            {
                Console.WriteLine("Incorrect input");
                Environment.Exit(0);
            }
            return;
        }

        public static void DetermineWinner(Game g)
        {
            if (g.playerMove == g.computerMove)
            {
                g.result = "Draw!";
            }
            else
            {
                for (int i = g.playerMove + 1; i < g.playerMove + ((g.countOfMoves - 1) / 2); i++)
                {
                    if (g.computerMove == i % g.countOfMoves)
                    {
                        g.result = "You win!";
                        return;
                    }
                }
                g.result = "You lose!";
            }
            return;
        }
    }
}

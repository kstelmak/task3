// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.Arm;
using System.IO;
using System.Xml.Linq;

//using System.Security.Cryptography;

namespace task3
{
    internal class Program
    {
        static void CheckArgs(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 == 0 || args.Count() != args.Distinct().Count())
            {
                Console.WriteLine("all strings must be different! the number of strings must be odd and more than 3");
                Environment.Exit(0); 
            }
        }

        static int MakeComputerMove(int count)
        {
            Random rnd = new Random();
            int move = rnd.Next(0, count);
            return move;
        }

        static void Main(string[] args)
        {
            CheckArgs(args);
            Game game = new Game();
            game.countOfMoves = args.Count();
            string key = Security.CreateStrongRandomKey();
            game.computerMove = MakeComputerMove(args.Count());
            string hexHMAC = Security.CreateHMAC(key, args[game.computerMove]);
            Console.WriteLine("HMAC: " + hexHMAC);
            Game.ShowMenu(args);
            Game.GetPlayerMove(args, game);
            Console.WriteLine("Computer move: " + args[game.computerMove]);
            Game.DetermineWinner(game);
            Console.WriteLine(game.result);
            Console.WriteLine("HMAC key: " + key);
        }
    }
}


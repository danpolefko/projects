using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class DisplayManager
    {
        public void DisplayStartMenu()
        {
            Console.WriteLine("                     BATTLESHIP!!!            ");
            Console.WriteLine();
            Console.WriteLine("             ,:',:`,:' ");
            Console.WriteLine("                   __||_||_||_||__ ");
            Console.WriteLine(@"              ____|' ' ' ' ' ' ' '|___");
            Console.WriteLine(@"              \  '''''''''''''''''''' | ");
            Console.WriteLine("    ~~djp~^ ~^ ~^^ ~^ ~^ ~^ ~^ ~^ ~^ ~^ ~~^ ~^ ~^^ ~~^ ~^ ");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void DisplayBoard(Board board)
        {  // Displays shot history/board of opponent
            Console.WriteLine("   A  B  C  D  E  F  G  H  I  J  ");
            for (int cols = 1; cols <= 10; cols++)
            {
                if (cols < 10)
                {
                    Console.Write(" ");
                    Console.Write(cols);
                }
                else Console.Write(cols);
                for (int rows = 1; rows <= 10; rows++)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Coordinate coord = new Coordinate(rows, cols);
                    if (board.ShotHistory.ContainsKey(coord))
                    {
                        ShotHistory spotResult = board.ShotHistory[coord];
                        switch (spotResult)
                        {
                            case ShotHistory.Hit:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" H ");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case ShotHistory.Miss:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(" M ");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        public void Victory(string playerName)
        {

            Console.Clear();
            Console.WriteLine($"{playerName}, you have won the game!!!");
            Console.WriteLine();
            Console.WriteLine(@"      __                 __ ");
            Console.WriteLine(@"     (  |               |  ) ");
            Console.WriteLine(@"  ____\  \             /  /_____");
            Console.WriteLine(@" (____ _) \           /   (_____)");
            Console.WriteLine(@" (_____ ) _)__('')__(_  ( _____)");
            Console.WriteLine(@" (__ ___)  )  |__|  (   (_ ___)");
            Console.WriteLine(@" (_____)__/  /_/\_\  \__(____)");
            Console.WriteLine();
            Console.WriteLine("Press any key to quit...");
        }
        public void DisplayOwnBoard(Board ownBoard)
        {
            throw new NotImplementedException();
        }
    }
}

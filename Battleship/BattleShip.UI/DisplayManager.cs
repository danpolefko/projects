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
    }
}

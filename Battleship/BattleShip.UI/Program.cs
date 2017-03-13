using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            InputManager im = new InputManager();
            DisplayManager dm = new DisplayManager();
            GameManager gm = new GameManager(im, dm);
            gm.StartGame();
        }
    }
}

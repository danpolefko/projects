using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class GameManager
    {
        private DisplayManager _dm;
        private InputManager _im;

        Player player1 = new Player();
       
        Player player2 = new Player();

        public GameManager(InputManager im, DisplayManager dm)
        {
            _dm = dm;
            _im = im;
        }

        public void StartGame()
        {
            _dm.DisplayStartMenu();
            player1.PlayerName = _im.GetPlayerName("1");
            player2.PlayerName =_im.GetPlayerName("2");
          //  Console.WriteLine(player1.PlayerName);
          //  Console.WriteLine(player2.PlayerName);
            Console.ReadKey();
        }
    }
}

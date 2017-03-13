using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class InputManager
    {
        public string GetPlayerName(string playerNumber)
        {
            string name;

            Console.Write("Player {0}, please enter your name: ", playerNumber);
            name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) == true)
            {
                name = "Player " + playerNumber;
            }

            return name;           
        }
    }
}

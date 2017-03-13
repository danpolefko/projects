using BattleShip.BLL.Requests;
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

        public Coordinate getCoordinate()
        {
            string input;
            int x;
            int y;

            do
            {
                Console.Write($"Enter a coordinate, A-J for x-axis and 1-10 for y-axis, ex D5:  ");
                input = Console.ReadLine().ToUpper();

                if (input.Length == 3 && input[0] >= 'A' && input[0] <= 'J' && input[1] == '1' && input[1] == '0')
                {
                    x = convertX(input[0]);
                    y = 10;

                    return new Coordinate(x, y);
                }
                else if (input.Length == 2 && input[0] >= 'A' && input[0] <= 'J' && input[1] >= 1 && input[1] <= 9)
                {
                    x = convertX(input[0]);
                    y = int.Parse(input.Substring(1, 1));

                    return new Coordinate(x, y);
                }
                else Console.WriteLine("That is not a valid coordinate. Try again!");

            } while (true);

        }

        private int convertX(char x)
        {
            switch (x)
            {
                case 'A':
                    return 1;
                case 'B':
                    return 2;
                case 'C':
                    return 3;
                case 'D':
                    return 4;
                case 'E':
                    return 5;
                case 'F':
                    return 6;
                case 'G':
                    return 7;
                case 'H':
                    return 8;
                case 'I':
                    return 9;
                case 'J':
                    return 10;
                default:
                    Console.WriteLine("That is not a valid coordinate. Try again!");
                    return 0;
            }
        }

        public ShipDirection getDirection()
        {
            string input;
            do
            {
                Console.WriteLine("Enter a direction for the ship to face. 1 = Up, 2 = Down, 3 = Left, 4 = Right ");
                input = Console.ReadLine();

                if (input.Length == 1 && input[0] > '0' && input[0] < '5')
                {
                    switch (input[0])
                    {
                        case '1':
                            return ShipDirection.Up;
                        case '2':
                            return ShipDirection.Down;
                        case '3':
                            return ShipDirection.Left;
                        case '4':
                            return ShipDirection.Down;
                        default:
                            break;
                    }
                }
                else Console.WriteLine("That is not a valid direction. Try Again!");
            } while (true);
        }
    }
}

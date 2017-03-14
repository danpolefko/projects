using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
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

        bool isPlayer1Turn = true;

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
            SetUpBoards();

            Console.ReadKey();
        }

        private void SetUpBoards()
        {
            PlaceShips(player1);
            PlaceShips(player2);
            PlayGame();

            //throw new NotImplementedException();
        }

        public void PlayGame()
        {
            bool _quitGame = false;
            while(!_quitGame)
            {
                if(isPlayer1Turn)
                {
                    _quitGame = TakeTurn(player1.PlayerName, player2.PlayerBoard);
                }
                else
                {
                    _quitGame = TakeTurn(player2.PlayerName, player1.PlayerBoard);
                }

                isPlayer1Turn = !isPlayer1Turn;
            }
        }

        public bool TakeTurn(string playerName, Board opponentBoard)
        {
            bool continueTurns = true;

            while (continueTurns)
            {
                Console.Clear();
                _dm.DisplayBoard(opponentBoard);
                Console.WriteLine($"{playerName}, it's your turn to take a shot ");
                Coordinate coordinate = _im.getCoordinate();

                FireShotResponse response = opponentBoard.FireShot(coordinate);
                switch (response.ShotStatus)
                {
                    case ShotStatus.Invalid:
                        Console.WriteLine("Invalid Entry! Try Again. Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case ShotStatus.Duplicate:
                        Console.WriteLine("You already shot there! Try again. Press any key to continue. ");
                        Console.ReadKey();
                        break;
                    case ShotStatus.Miss:
                        Console.WriteLine("You missed! Press any Key to continue");
                        Console.ReadKey();
                        continueTurns = false;
                        return false;
                    case ShotStatus.Hit:
                        Console.WriteLine($"You hit the {response.ShipImpacted}!  Press any key to continue.");
                        Console.ReadKey();
                        continueTurns = false;
                        return false;
                    case ShotStatus.HitAndSunk:
                        Console.WriteLine($"You sank the {response.ShipImpacted}!  Press any key to continue.");
                        Console.ReadKey();
                        continueTurns = false;
                        return false;
                    case ShotStatus.Victory:
                        Console.WriteLine($"{playerName}, you have won the game!!!");
                        _dm.Victory(playerName);
                        Console.ReadKey();
                        continueTurns = false;
                        return true;
                    default:
                        break;
                }
            }
            return true;
        }

        public void PlaceShips(Player player)
        {
            Board blankBoard = new Board();
            _dm.DisplayBoard(blankBoard);
                      
            bool waitForOk = false;
            
            foreach (ShipType ship in Enum.GetValues(typeof(ShipType)))
            {
               // _dm.DisplayOwnBoard(player.OwnBoard);
                // Console.WriteLine(ship);
                do
                {
                    Console.WriteLine("{0}, Get ready to place your {1}", player.PlayerName, ship);
                    Coordinate coordinate = _im.getCoordinate();
                    ShipDirection direction = _im.getDirection();

                    PlaceShipRequest request = new PlaceShipRequest()
                    {
                        Coordinate = coordinate,
                        Direction = direction,
                        ShipType = ship
                    };

                    var response = player.PlayerBoard.PlaceShip(request);

                    switch (response)
                    {
                        case ShipPlacement.NotEnoughSpace:
                            Console.WriteLine("There isn't enough space there. Try again.");
                            waitForOk = false;
                            break;
                        case ShipPlacement.Overlap:
                            Console.WriteLine("There is another ship in the way. Try again. ");
                            waitForOk = false;
                            break;
                        case ShipPlacement.Ok:
                           // player.OwnBoard.PlaceShip(request);
                            waitForOk = true;
                            break;
                      //  default:
                           // waitForOk = false;
                    }

                } while (waitForOk != true);
            }          
        }
    }
}

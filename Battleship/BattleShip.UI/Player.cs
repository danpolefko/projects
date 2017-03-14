using BattleShip.BLL.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class Player
    {
        public string PlayerName;
        public Board PlayerBoard = new Board();
        public Board OwnBoard = new Board();
    }
}

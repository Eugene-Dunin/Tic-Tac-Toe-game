using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Player;

namespace iTechArt.TicTacToe.Foundation.Events.UIToGameArgs
{
    public class RegisterEventArgs : EventArgs
    {
        public HashSet<Player> Players { get; }

        public Player FirstPlayer { get; }


        public RegisterEventArgs(HashSet<Player> Players)
        {
            this.Players = Players;
        }
    }
}

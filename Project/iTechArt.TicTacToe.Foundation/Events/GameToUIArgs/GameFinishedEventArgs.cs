using iTechArt.Tic_Tac_Toe_Game.Foundation.Events;
using iTechArt.TicTacToe.Foundation.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Player;

namespace iTechArt.TicTacToe.Foundation.Events.GameToUIArgs
{
    public class GameFinishedEventArgs: EventArgs
    {
        public GameResult GameResult { get; }

        public Player[] Players { get; }


        public GameFinishedEventArgs(GameResult gameResult, Player[] players)
        {
            GameResult = gameResult;

            Players = players;
        }
    }
}

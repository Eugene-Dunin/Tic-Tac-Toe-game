using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Player;

namespace Tic_Tac_Toe_Game.Events
{
    public enum GameResult
    {
        Draw,
        Win,
        Winners
    }

    public class GameFinishedEventArgs: EventArgs
    {
        public GameFinishedEventArgs(
            GameResult gameResult, Player[] players)
        {
            GameResult = gameResult;
            Players = players;
        }

        public GameResult GameResult { get; }
        public Player[] Players { get; }
    }
}

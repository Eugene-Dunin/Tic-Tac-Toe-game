using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Player;

namespace Tic_Tac_Toe_Game.Events
{
    enum GameResult
    {
        Draw,
        Win,
        Winners
    }

    class GameFinishedEventArgs: EventArgs
    {
        private readonly GameResult gameResult;
        private readonly Player[] players;

        public GameFinishedEventArgs(
            GameResult gameResult, Player[] players)
        {
            this.gameResult = gameResult;
            this.players = players;
        }

        public GameResult GameResult { get => gameResult; }
        public Player[] Players { get => players; }
    }
}

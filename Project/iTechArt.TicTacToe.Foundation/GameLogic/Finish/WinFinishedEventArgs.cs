using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.GameLogic.Finish
{
    public class WinFinishedEventArgs : FinishedEventArgs
    {
        public IReadOnlyList<ICell> WinCells { get; }

        public IPlayer WinPlayer { get; }


        public WinFinishedEventArgs(IReadOnlyList<ICell> winCells, IPlayer winPlayer)
            : base(GameResult.Win)
        {
            WinCells = winCells;
            WinPlayer = winPlayer;
        }
    }
}
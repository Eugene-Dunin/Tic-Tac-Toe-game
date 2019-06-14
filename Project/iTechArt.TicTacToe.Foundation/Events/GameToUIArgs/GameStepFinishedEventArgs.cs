using iTechArt.TicTacToe.Foundation.GameBoard.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Events.GameToUIArgs
{
    public class GameStepFinishedEventArgs : EventArgs
    {
        public IReadOnlyList<ICell> Cells { get; }


        public GameStepFinishedEventArgs(IReadOnlyList<ICell> cells)
        {
            Cells = cells;
        }
    }
}

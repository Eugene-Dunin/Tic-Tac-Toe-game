using iTechArt.TicTacToe.Foundation.GameBoard.Base;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Events.GameToUIArgs
{
    public class GameStepFinishedEventArgs : EventArgs
    {
        public IEnumerable<ICell> Cells { get; }


        public GameStepFinishedEventArgs(IEnumerable<ICell> cells)
        {
            Cells = cells;
        }
    }
}

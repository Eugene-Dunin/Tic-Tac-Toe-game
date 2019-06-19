using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Base
{
    public abstract class BaseLine
    {
        private bool? isWin;


        public IReadOnlyList<ICell> Cells { get; }

        public bool IsWin => isWin ?? CalcState();


        protected BaseLine(IBoard board, Func<ICell, bool> predicate)
        {
            Cells = board.Where(predicate).ToList();
        }


        private bool CalcState()
        {
            var filledCells = Cells.Where(cell => !cell.IsEmpty).ToList();

            if (filledCells.Any(cell => cell.Figure.Type != filledCells.First().Figure.Type))
            {
                isWin = false;
            }

            if (filledCells.Count == Cells.Count())
            {
                isWin = true;
            }

            return false;
        }
    }
}
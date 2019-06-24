using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    public abstract class BaseLine : ILine
    {
        private bool? isWin;


        public IReadOnlyList<ICell> Cells { get; }

        public bool IsWin
        {
            get
            {
                if (!isWin.HasValue)
                {
                    isWin = CalcIfIsWin();
                }

                return isWin ?? false;
            }
        }


        protected BaseLine(IBoard board, Func<ICell, bool> predicate)
        {
            Cells = board.Where(predicate).ToList();
        }


        private bool? CalcIfIsWin()
        {
            var filledCells = Cells.Where(cell => !cell.IsEmpty).Select(cell => cell.Figure.Type).ToList();
            var inProgress = filledCells.Distinct().Count() == filledCells.Count() - 1;

            if (filledCells.Count() != Cells.Count && inProgress)
            {
                return null;
            }

            return inProgress;
        }
    }
}
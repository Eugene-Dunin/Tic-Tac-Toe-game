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
                    isWin = CalcState();
                }

                return isWin ?? false;
            }
        }


        protected BaseLine(IBoard board, Func<ICell, bool> predicate)
        {
            Cells = board.Where(predicate).ToList();
        }


        private bool? CalcState()
        {
            if (!Cells.Select(cell => cell.IsEmpty).Distinct().Any())
            {
                return null;
            }

            return !Cells.Select(cell => cell.Figure.Type).Distinct().Any();
        }
    }
}
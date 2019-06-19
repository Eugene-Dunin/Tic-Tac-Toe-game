using System;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Interfaces.Internals;

namespace iTechArt.TicTacToe.Foundation.Cells
{
    public class Cell : ICellInternal
    {
        public IFigure Figure { get; private set; }


        IFigure ICellInternal.Figure
        {
            set
            {
                if(IsEmpty)
                {
                    Figure = value;
                }
                else
                {
                    throw new InvalidOperationException("Cell is filled.");
                }
            }
        }


        public int Row { get; }

        public int Column { get; }

        public bool IsEmpty => Figure == null;


        public Cell(int row, int col)
        {
            Row = row;
            Column = col;
        }
    }
}
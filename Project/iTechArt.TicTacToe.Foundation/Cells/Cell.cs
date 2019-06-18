using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Interfaces.Internals;

namespace iTechArt.TicTacToe.Foundation.GameBoard
{
    public class Cell : ICellInternal
    {
        public IFigure Figure { get; set; }

        public int Row { get; }
        public int Column { get; }

        public bool IsEmpty => Figure == null;

        public Cell(int row, int col)
        {
            Row = row;
            Column = Column;
        }

        public void SetFigure(IFigure figure)
        {
            if (IsEmpty)
            {
                Figure = figure;
            }
            else
            {
                throw new InvalidOperationException("Cell is filled.");
            }
        }
    }
}

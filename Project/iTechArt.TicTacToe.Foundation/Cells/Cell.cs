using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Interfaces.Internals;

namespace iTechArt.TicTacToe.Foundation.Cells
{
    public class Cell : ISetCell
    {
        public IFigure Figure { get; private set; }

        public int Row { get; }
        public int Column { get; }

        public bool IsEmpty => Figure == null ? true : false;

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

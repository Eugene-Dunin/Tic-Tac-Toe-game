﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Cells
{
    class Cell : ICell
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

        public FillCellResult SetFigure(IBoard board, IFigure figure)
        {
            if (board == null)
            {
                return FillCellResult.NullBoard;
            }

            if(figure == null)
            {
                return FillCellResult.NullFigure;
            }

            if (board.Cells.Contains(this))
            {
                if (IsEmpty)
                {
                    Figure = figure;

                    return FillCellResult.Successful;
                }

                return FillCellResult.Occupied;
            }

            return FillCellResult.Forbidden;
        }
    }
}

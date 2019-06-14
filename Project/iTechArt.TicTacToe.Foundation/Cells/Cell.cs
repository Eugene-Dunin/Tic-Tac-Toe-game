using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArt.Tic_Tac_Toe_Game.Foundation.Cells;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.GameBoard
{
    class Cell : ICell
    {
        public IFigure Figure { get; private set; }

        public bool IsEmpty => Figure != null ? true : false;

        public int Row { get; }
        public int Column { get; }
        

        public Cell(int row, int col)
        {
            Row = row;
            Column = Column;
        }

        public FillCellResult SetFigure(IBoard board, IFigure figure)
        {
            if (board.Cells.Contains(this)) {
           
                if (IsEmpty)
                {
                    Figure = figure;

                    return FillCellResult.Success;
                }

                return FillCellResult.Occupied;
            }

            return FillCellResult.Forbidden;
        }
    }
}

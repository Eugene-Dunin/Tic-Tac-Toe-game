using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArt.TicTacToe.Foundation.Figures.Base;
using iTechArt.TicTacToe.Foundation.GameBoard.Base;


namespace iTechArt.TicTacToe.Foundation.GameBoard
{
    class BoardCell : ICell
    {
        public IFigure Figure { get; set; }

        public FigureType GetStoredFigureType
        {
            get
            {
                if (Figure != null)
                {
                    return Figure.GetFigureType;
                }
                return FigureType.None;
            }
        }

        public int Row { get; }
        public int Column { get; }
        

        public BoardCell(int row, int col)
        {
            Row = row;
            Column = Column;
        }
    }
}

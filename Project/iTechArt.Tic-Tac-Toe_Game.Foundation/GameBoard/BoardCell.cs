using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArt.Tic_Tac_Toe_Game.Foundation.Figures;
using iTechArt.TicTacToeGame.Foundation.GameBoard.Base;

namespace iTechArt.Tic_Tac_Toe_Game.Foundation.GameLogic
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

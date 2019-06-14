using iTechArt.TicTacToe.Foundation.Figures.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.GameBoard.Base
{
    public interface IGameBoardStorage
    {
        void ClearGameBoard();

        void FillCell(IFigure figure, int row, int column);

        IReadOnlyList<ICell> GetCellsData();
    }
}

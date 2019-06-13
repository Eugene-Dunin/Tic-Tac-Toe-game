using iTechArt.Tic_Tac_Toe_Game.Foundation.Figures;
using iTechArt.Tic_Tac_Toe_Game.Foundation.GameLogic;
using iTechArt.TicTacToeGame.Foundation.GameBoard.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Foundation.GameBoard.Base
{
    public interface IGameBoardStorage
    {
        void ClearGameBoard();

        void FillCell(IFigure figure, int row, int column);

        IReadOnlyList<ICell> GetCellsData();
    }
}

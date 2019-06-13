using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Game.Foundation.Figures;

namespace Tic_Tac_Toe_Game.Foundation.GameLogic
{
    public struct CellCoordinates
    {
        public int Row;
        public int Column;

        public CellCoordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }

    public interface IGameBoardStorage
    {
        void ClearGameBoard();
        void FillCell(Figure figure, CellCoordinates cellCoordinates);
        Figure[,] GetCellsData();
    }
}

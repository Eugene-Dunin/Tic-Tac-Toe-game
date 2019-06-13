using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tic_Tac_Toe_Game.Events;
using Tic_Tac_Toe_Game.Foundation.Events;
using Tic_Tac_Toe_Game.Foundation.Figures;
using Tic_Tac_Toe_Game.Foundation.GameLogic;
using Tic_Tac_Toe_Player;

namespace Tic_Tac_Toe_Game
{
    class GameBoardStorage : IGameBoardStorage
    {
        private const string FILL_CELL_EXCEPTION_MESS = "This cell is occupied";
        private const string BOARD_IS_NOT_CONTAIN_CELL_MESS = "This cell is not exist.";
        public Figure[,] cells;
        protected readonly int matrixSize;

        protected GameBoardStorage(int matrixSize)
        {
            cells = new Figure[matrixSize, matrixSize];
            this.matrixSize = matrixSize;
        }

        public void ClearGameBoard()
        {
            for (int rowInd = 0; rowInd < matrixSize; rowInd++)
                for (int colInd = 0; colInd < matrixSize; colInd++)
                {
                    cells[rowInd, colInd] = null;
                }
        }

        public void FillCell(Figure figure, CellCoordinates cellCoordinates)
        {
            try
            {
                if(cells[cellCoordinates.Row, cellCoordinates.Column] != null)
                {
                    cells[cellCoordinates.Row, cellCoordinates.Column] = figure;
                }
                else
                {
                    throw new InvalidOperationException(FILL_CELL_EXCEPTION_MESS);
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException(BOARD_IS_NOT_CONTAIN_CELL_MESS);
            }
        }

        public Figure[,] GetCellsData()
        {
            return cells;
        }
    }
}

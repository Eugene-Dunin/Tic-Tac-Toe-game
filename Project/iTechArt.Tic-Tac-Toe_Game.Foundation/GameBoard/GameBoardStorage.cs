using iTechArt.TicTacToe.Foundation.Figures.Base;
using iTechArt.TicTacToe.Foundation.GameBoard.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Foundation.GameLogic;

namespace iTechArt.TicTacToe.Foundation.GameBoard
{
    class GameBoardStorage : IGameBoardStorage
    {
        private const string FILL_CELL_EXCEPTION_MESS = "This cell is occupied";
        private const string BOARD_IS_NOT_CONTAIN_CELL_MESS = "This cell is not exist.";
        public List<BoardCell> cells;
        protected readonly int matrixSize;

        public GameBoardStorage(int matrixSize)
        {
            cells = new List<BoardCell>(matrixSize * matrixSize);
            this.matrixSize = matrixSize;
            CreateCells();
        }

        private void CreateCells()
        {
            for (int cellRowNum = 1; cellRowNum <= matrixSize; cellRowNum++)
            {
                for (int cellColumnNum = 1; cellColumnNum <= matrixSize; cellColumnNum++)
                {
                    cells.Add(new BoardCell(cellRowNum, cellColumnNum));
                }
            }
        }

        public void ClearGameBoard()
        {
            cells.ForEach(cell => cell.Figure = null);
        }

        public void FillCell(IFigure figure, int row, int column)
        {
            var matchCell = cells.Find(cell => cell.Row == row && cell.Column == column);
            if (matchCell != null)
            {
                if (matchCell.GetStoredFigureType != FigureType.None)
                {
                    matchCell.Figure = figure;
                }
                throw new InvalidOperationException(FILL_CELL_EXCEPTION_MESS);
            }                
            else
            {
                throw new InvalidOperationException(BOARD_IS_NOT_CONTAIN_CELL_MESS);
            }
        }

        public IReadOnlyList<ICell> GetCellsData()
        {
            return cells;
        }
    }
}

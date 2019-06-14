using iTechArt.Tic_Tac_Toe_Game.Foundation.GameBoard;
using iTechArt.Tic_Tac_Toe_Game.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures.Base;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iTechArt.TicTacToe.Foundation.GameBoard
{
    class GameBoard : IBoard
    {
        private const string FILL_CELL_EXCEPTION_MESS = "This cell is occupied";
        private const string BOARD_IS_NOT_CONTAIN_CELL_MESS = "This cell is not exist.";

        public List<Cell> cells;

        protected readonly int matrixSize;

        private ICellFactory cellFactory;

        private IFigureFactory figureFactory;

        public ICell this[int index] => cells.ElementAt(index);


        public GameBoard(int matrixSize, ICellFactory cellFactory, IFigureFactory figureFactory)
        {
            if (matrixSize >= 3)
            {
                cells = new List<Cell>(matrixSize * matrixSize);

                this.cellFactory = cellFactory ?? throw new NullReferenceException();

                this.figureFactory = figureFactory ?? throw new NullReferenceException();

                this.matrixSize = matrixSize;

                CreateCells();
            }
            else
            {
                throw new ArgumentException("Matrix size must be 3 or more.");
            }
        }


        private void CreateCells()
        {
            cells = Enumerable.Range(1, matrixSize)
                .SelectMany(row => (IEnumerable<Cell>)Enumerable.Range(1, matrixSize).Select(col => cellFactory.GetCell(row, col)))
                .ToList();
        }


        public FillBoardCellResult FillBoardCell(FigureType figureType, int row, int column)
        {
            var matchCell = cells.Find(cell => cell.Row == row && cell.Column == column);
            if (matchCell != null)
            {
                if (!matchCell.IsEmpty)
                {
                    matchCell.SetFigure(this, figureFactory.GetFigure(figureType));

                    return FillBoardCellResult.Succeed;
                }

                return FillBoardCellResult.OccupiedCell;
            }

            return FillBoardCellResult.NotExistedCell;
        }

        public IEnumerator<ICell> GetEnumerator()
        {
            return Enumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Enumerator();
        }

        private IEnumerator<ICell> Enumerator()
        {
            foreach (var cell in cells)
            {
                yield return cell;
            }
        }
    }
}

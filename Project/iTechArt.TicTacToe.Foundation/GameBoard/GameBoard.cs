using iTechArt.TicTacToe.Foundation.Cells;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iTechArt.TicTacToe.Foundation.GameBoard
{
    class GameBoardStorage : IBoard
    {
        private const string FILL_CELL_EXCEPTION_MESS = "This cell is occupied";
        private const string BOARD_IS_NOT_CONTAIN_CELL_MESS = "This cell is not exist.";

        public List<Cell> cells;


        protected readonly int matrixSize;


        private readonly IFigureFactory figureFactory;

        private ICellFactory cellFactory;


        public IReadOnlyList<ICell> Cells => cells;


        public ICell this[int index] => cells.ElementAt(index);


        public GameBoardStorage(
            int matrixSize, IFigureFactory figureFactory, ICellFactory cellFactory)
        {
            this.figureFactory = figureFactory ?? throw new NullReferenceException();
            this.cellFactory = cellFactory ?? throw new NullReferenceException();

            if (matrixSize >= 3)
            {
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
            cells = cells = Enumerable.Range(1, matrixSize)
                .SelectMany(row => (IEnumerable<Cell>)Enumerable.Range(1, matrixSize).Select(col => cellFactory.GetCell(row, col)))
                .ToList();
        }


        public FillCellResult FillCell(FigureType figureType, int row, int column)
        {
            var matchCell = cells.Find(cell => cell.Row == row && cell.Column == column);
            if(matchCell != null)
            {
                return matchCell.SetFigure(this, figureFactory.GetFigure(figureType));
            }

            return FillCellResult.NotContain;
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
            foreach(var cell in cells)
            {
                yield return cell;
            }
        }
    }
}

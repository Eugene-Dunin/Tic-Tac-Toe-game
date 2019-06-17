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
    public sealed class Board : IBoard
    {
        private IReadOnlyList<Cell> cells;


        private readonly int matrixSize;


        private readonly IFigureFactory figureFactory;

        private ICellFactory cellFactory;


        public ICell this[int index] => cells.ElementAt(index);


        public Board(
            int matrixSize, IFigureFactory figureFactory, ICellFactory cellFactory)
        {
            this.figureFactory = figureFactory;
            this.cellFactory = cellFactory;

            this.matrixSize = matrixSize;
            CreateCells();

        }
        private void CreateCells()
        {
            cells = cells = Enumerable.Range(1, matrixSize)
                .SelectMany(row => (IEnumerable<Cell>)Enumerable.Range(1, matrixSize).Select(col => cellFactory.GetCell(row, col)))
                .ToList();
        }


        public FillCellResult FillCell(FigureType figureType, int row, int column)
        {
            var matchCell = cells.Where(cell => cell.Row == row && cell.Column == column).First();
            if(matchCell != null)
            {
                if (matchCell.IsEmpty)
                {
                    matchCell.SetFigure(figureFactory.GetFigure(figureType));

                    return FillCellResult.Successful;
                }

                return FillCellResult.Occupied;
            }

            return FillCellResult.BoardNotContain;
        }

        public IEnumerator<ICell> GetEnumerator()
        {
            foreach (var cell in cells)
            {
                yield return cell;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

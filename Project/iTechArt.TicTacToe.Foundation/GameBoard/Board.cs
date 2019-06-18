using iTechArt.TicTacToe.Foundation.GameBoard;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArt.TicTacToe.Foundation.Interfaces.Internals;

namespace iTechArt.TicTacToe.Foundation.GameBoard
{
    public sealed class Board : IBoardInternal
    {
        private readonly IReadOnlyList<ICellInternal> _cells;

        private readonly IFigureFactory _figureFactory;

        private readonly ICellFactory _cellFactory;


        public int MatrixSize { get; }


        public ICell this[int row, int column] => _cells.First(cell => cell.Row == row && cell.Column == column);


        public Board(
            int matrixSize, IFigureFactory figureFactory, ICellFactory cellFactory)
        {
            _figureFactory = figureFactory;

            _cellFactory = cellFactory;

            MatrixSize = matrixSize;

            _cells = CreateCells();

        }
        private IReadOnlyList<ICellInternal> CreateCells()
        {
            return Enumerable.Range(1, MatrixSize)
                .SelectMany(row => (IEnumerable<ICellInternal>)Enumerable.Range(1, MatrixSize).Select(col => _cellFactory.CreateCell(row, col)))
                .ToList();
        }


        public FillCellResult FillCell(FigureType figureType, int row, int column)
        {
            var matchCell = (ICellInternal)this[row, column];
            if (matchCell != null)
            {
                if (matchCell.IsEmpty)
                {
                    matchCell.Figure = _figureFactory.GreateFigure(figureType);

                    return FillCellResult.Successful;
                }

                return FillCellResult.CellOccupied;
            }

            return FillCellResult.CellNotFound;
        }

        public IEnumerator<ICell> GetEnumerator()
        {
            return _cells.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cells.GetEnumerator();
        }
    }
}

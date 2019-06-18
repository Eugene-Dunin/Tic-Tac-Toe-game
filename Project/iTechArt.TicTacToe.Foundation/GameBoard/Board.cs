using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces.Internals;

namespace iTechArt.TicTacToe.Foundation.GameBoard
{
    public sealed class Board : IBoardInternal
    {
        private readonly IReadOnlyList<ICellInternal> _cells;

        private readonly IFigureFactory _figureFactory;

        private readonly ICellFactory _cellFactory;


        public int Size { get; }


        public ICell this[int row, int column] => _cells.First(cell => cell.Row == row && cell.Column == column);


        public Board(
            int matrixSize, IFigureFactory figureFactory, ICellFactory cellFactory)
        {
            _figureFactory = figureFactory;

            _cellFactory = cellFactory;

            Size = matrixSize;

            _cells = CreateCells();

        }
        private IReadOnlyList<ICellInternal> CreateCells()
        {
            return Enumerable.Range(1, Size)
                .SelectMany(row => (IEnumerable<ICellInternal>)Enumerable.Range(1, Size).Select(col => _cellFactory.CreateCell(row, col)))
                .ToList();
        }


        public FillCellResult FillCell(FigureType figureType, int row, int column)
        {
            var matchCell = (ICellInternal)this[row, column];
            if (matchCell == null)
            {
                return FillCellResult.CellNotFound;
            }
            if (!matchCell.IsEmpty)
            {
                return FillCellResult.CellOccupied;
            }
            matchCell.Figure = _figureFactory.CreateFigure(figureType);

            return FillCellResult.Successful;

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

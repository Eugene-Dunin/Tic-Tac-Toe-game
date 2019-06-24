using System;
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
        private readonly IFigureFactory _figureFactory;
        private readonly ICellFactory _cellFactory;

        private readonly IReadOnlyList<ICellInternal> _cells;
 

        public int Size { get; }

        public ICell this[int row, int column] =>
            TryGetCell(row, column, out var cell) 
                ? cell
                : throw new InvalidOperationException($"Board not contain cell with [{row},{column}] coordinates.");


        public Board(int matrixSize, IFigureFactory figureFactory, ICellFactory cellFactory)
        {
            _figureFactory = figureFactory;
            _cellFactory = cellFactory;

            Size = matrixSize;

            _cells = CreateCells();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        FillCellResult IBoardInternal.FillCell(FigureType figureType, int row, int column)
        {
            if (!TryGetCell(row, column, out var cell))
            {
                return FillCellResult.CellNotFound;
            }
            if (!cell.IsEmpty)
            {
                return FillCellResult.CellOccupied;
            }
            cell.Figure = _figureFactory.CreateFigure(figureType);

            return FillCellResult.Successful;

        }


        public IEnumerator<ICell> GetEnumerator()
        {
            return _cells.GetEnumerator();
        }


        private IReadOnlyList<ICellInternal> CreateCells()
        {
            return Enumerable.Range(1, Size)
                .SelectMany(row => Enumerable.Range(1, Size).Select(col => _cellFactory.CreateCell(row, col)))
                .Cast<ICellInternal>()
                .ToList();
        }

        private bool TryGetCell(int row, int column, out ICellInternal cell)
        {
            cell = _cells.FirstOrDefault(cellInternal => cellInternal.Row == row && cellInternal.Column == column);
            return cell != null;
        }
    }
}
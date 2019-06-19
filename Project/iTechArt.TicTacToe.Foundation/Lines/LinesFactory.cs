using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Base;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    public class LinesFactory : ILinesFactory
    {
        public IReadOnlyList<BaseLine> CreateLines(IBoard board)
        {
            var boardLines = new List<BaseLine>();
            boardLines.AddRange(Enumerable.Range(1, board.Size).Select(row =>
                new RowLine(board, row)));
            boardLines.AddRange(Enumerable.Range(1, board.Size).Select(row =>
                new ColumnLine(board, row)));
            boardLines.Add(new MainDiagonalLine(board));
            boardLines.Add(new SideDiagonalLine(board));

            return boardLines;
        }
    }
}
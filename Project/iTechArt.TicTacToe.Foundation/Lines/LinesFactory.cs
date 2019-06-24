using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    public class LinesFactory : ILinesFactory
    {
        public IReadOnlyList<ILine> CreateLines(IBoard board)
        {
            var boardLines = new List<LineBase>();
            boardLines.AddRange(Enumerable.Range(1, board.Size).Select(row =>
                new Row(board, row)));
            boardLines.AddRange(Enumerable.Range(1, board.Size).Select(row =>
                new Column(board, row)));
            boardLines.Add(new MainDiagonal(board));
            boardLines.Add(new SideDiagonal(board));

            return boardLines;
        }
    }
}
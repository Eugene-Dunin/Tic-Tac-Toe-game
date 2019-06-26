using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    public class LinesFactory : ILinesFactory
    {
        public IReadOnlyList<ILine> CreateLines(IBoard board)
        {
            var rows = Enumerable.Range(1, board.Size).Select<int, ILine>(row => new Row(board, row));
            var cols = Enumerable.Range(1, board.Size).Select<int, ILine>(col => new Column(board, col));
            var diags = new ILine[] {new MainDiagonal(board), new SideDiagonal(board)};

            return rows.Concat(cols).Concat(diags).ToList();
        }
    }
}
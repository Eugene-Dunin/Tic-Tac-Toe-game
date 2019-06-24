using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    public class LinesFactory : ILinesFactory
    {
        public IReadOnlyList<ILine> CreateLines(IBoard board)
        {
            var rows = new ReadOnlyCollection<ILine>
                (Enumerable.Range(1, board.Size).Select(row => new Row(board, row)).Cast<ILine>().ToList());
            var cols = new ReadOnlyCollection<ILine>
                (Enumerable.Range(1, board.Size).Select(col => new Column(board, col)).Cast<ILine>().ToList());
            var diags = new ReadOnlyCollection<ILine>
                (new List<ILine> {new MainDiagonal(board), new SideDiagonal(board)});

            return rows.Concat(cols).Concat(diags).ToList();
        }
    }
}
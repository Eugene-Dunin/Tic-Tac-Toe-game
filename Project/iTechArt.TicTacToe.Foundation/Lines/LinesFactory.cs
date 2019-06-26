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
            var rows = Enumerable.Range(1, board.Size).Select<int, ILine>(row => new Row(board, row)).ToList();
            var cols = Enumerable.Range(1, board.Size).Select<int, ILine>(col => new Column(board, col)).ToList();
            var diagonals = new ILine[] {new MainDiagonal(board), new SideDiagonal(board)};

            return rows.Concat(cols).Concat(diagonals).ToList();
        }
    }
}
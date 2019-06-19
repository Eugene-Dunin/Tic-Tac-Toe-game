using iTechArt.TicTacToe.Foundation.Base;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    public class SideDiagonalLine : BaseLine
    {
        public SideDiagonalLine(IBoard board)
            : base(board, cell => cell.Row == (board.Size - cell.Column + 1))
        { }
    }
}
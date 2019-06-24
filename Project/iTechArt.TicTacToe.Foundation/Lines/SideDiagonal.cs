using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    public class SideDiagonal : ILine
    {
        public SideDiagonal(IBoard board)
            : base(board, cell => cell.Row == (board.Size - cell.Column + 1))
        {

        }
    }
}
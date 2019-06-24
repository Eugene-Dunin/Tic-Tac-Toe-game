using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    public class MainDiagonal : ILine
    {
        public MainDiagonal(IBoard board)
            : base(board, cell => cell.Row == cell.Column)
        {

        }
    }
}
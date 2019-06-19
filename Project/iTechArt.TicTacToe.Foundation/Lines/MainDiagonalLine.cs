using iTechArt.TicTacToe.Foundation.Base;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    public class MainDiagonalLine : BaseLine
    {
        public MainDiagonalLine(IBoard board)
            : base(board, cell => cell.Row == cell.Column)
        { }
    }
}
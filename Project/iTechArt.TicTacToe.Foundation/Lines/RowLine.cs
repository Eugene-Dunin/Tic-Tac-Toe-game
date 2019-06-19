using iTechArt.TicTacToe.Foundation.Base;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    public class RowLine : BaseLine
    {
        public RowLine(IBoard board, int row)
            : base(board, cell => cell.Row == row)
        {}
    }
}
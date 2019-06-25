using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    public class Row : LineBase
    {
        public Row(IBoard board, int row)
            : base(board, cell => cell.Row == row)
        {

        }
    }
}
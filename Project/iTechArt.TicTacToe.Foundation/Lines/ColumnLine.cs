using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    public class ColumnLine : BaseLine
    {
        public ColumnLine(IBoard board, int column)
            : base(board, cell => cell.Column == column)
        {

        }
    }
}
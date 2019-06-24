using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    public class Column : LineBase
    {
        public Column(IBoard board, int column)
            : base(board, cell => cell.Column == column)
        {

        }
    }
}
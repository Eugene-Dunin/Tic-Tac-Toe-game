using iTechArt.TicTacToe.Foundation.GameBoard;
using iTechArt.TicTacToe.Foundation.Figures;


namespace iTechArt.TicTacToe.Foundation.Interfaces.Internals
{
    internal interface IBoardInternal : IBoard
    {
        FillCellResult FillCell(FigureType figureType, int row, int column);
    }
}

namespace iTechArt.TicTacToe.Foundation.Interfaces.Internals
{
    internal interface ICellInternal : ICell
    {
        new IFigure Figure { set; }
    }
}

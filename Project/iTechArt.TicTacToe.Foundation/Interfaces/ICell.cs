namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface ICell
    {
        IFigure Figure { get; }

        bool IsEmpty { get; }

        int Row { get; }

        int Column { get; }
    }
}
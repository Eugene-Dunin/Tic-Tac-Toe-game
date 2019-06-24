namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IBoardFactory
    {
        IBoard CreateBoard(int size, IFigureFactory figureFactory, ICellFactory cellFactory);
    }
}
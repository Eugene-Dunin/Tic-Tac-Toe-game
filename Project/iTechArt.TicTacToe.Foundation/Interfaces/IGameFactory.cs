namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameFactory
    {
        IGame CreateGame(IGameConfig gameConfig);
    }
}
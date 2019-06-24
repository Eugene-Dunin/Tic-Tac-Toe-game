namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameInputProvider
    {
        (int row, int col) GetCellCoordinates(IPlayer player);
    }
}
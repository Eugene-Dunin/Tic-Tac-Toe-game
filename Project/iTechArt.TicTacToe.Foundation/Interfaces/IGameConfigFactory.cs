using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameConfigFactory
    {
        IGameConfig CreateGameConfig(IReadOnlyCollection<IPlayer> players, IPlayer firstPlayer, int boardSize);
    }
}
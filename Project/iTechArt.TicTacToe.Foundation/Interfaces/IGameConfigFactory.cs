using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameConfigFactory
    {
        IGameConfig CreateGameConfig(IReadOnlyList<IPlayer> players, IPlayer firstPlayer, int boardSize);
    }
}
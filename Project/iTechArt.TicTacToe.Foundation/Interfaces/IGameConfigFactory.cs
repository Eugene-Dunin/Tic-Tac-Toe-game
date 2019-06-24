using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameConfigFactory
    {
        IGameConfig CreateBaseGameConfigManager(ICollection<IPlayer> players, IPlayer firstPlayer, int boardSize);
    }
}
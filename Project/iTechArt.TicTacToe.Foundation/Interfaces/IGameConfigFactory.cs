using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Players;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameConfigFactory
    {
        IGameConfig CreateBaseGameConfigManager(ICollection<Player> players, Player firstPlayer, int boardSize);
    }
}
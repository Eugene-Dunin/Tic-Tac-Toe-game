using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Configs
{
    public class GameConfigFactory : IGameConfigFactory
    {
        public IGameConfig CreateBaseGameConfigManager(ICollection<IPlayer> players, IPlayer firstPlayer, int boardSize)
        {
            return new GameConfig(players, firstPlayer, boardSize);
        }
    }
}
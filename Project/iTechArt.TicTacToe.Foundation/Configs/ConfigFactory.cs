using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Configs
{
    public class ConfigFactory : IGameConfigFactory
    {
        public IGameConfig CreateGameConfig(IReadOnlyList<IPlayer> players, IPlayer firstPlayer, int boardSize)
        {
            return new Config(players, firstPlayer, boardSize);
        }
    }
}
using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Players;

namespace iTechArt.TicTacToe.Foundation.Configs
{
    public class GameConfigFactory : IGameConfigFactory
    {
        public IGameConfig CreateBaseGameConfigManager(ICollection<Player> players, Player firstPlayer, int boardSize)
        {
            return new GameConfig(players, firstPlayer, boardSize);
        }
    }
}
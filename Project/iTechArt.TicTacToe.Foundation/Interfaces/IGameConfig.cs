using iTechArt.TicTacToe.Foundation.Players;
using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameConfig
    {
        HashSet<Player> Players { get; }

        int BoardSize { get; }
    }
}

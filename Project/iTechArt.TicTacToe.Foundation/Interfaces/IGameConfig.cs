using iTechArt.TicTacToe.Foundation.Players;
using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameConfig
    {
        IReadOnlyList<IPlayer> Players { get; }

        IPlayer FirstPlayer { get; }

        int BoardSize { get; }
    }
}
using iTechArt.TicTacToe.Foundation.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameConfig
    {
        HashSet<Player> Players { get; }

        int BoardSize { get; }
    }
}

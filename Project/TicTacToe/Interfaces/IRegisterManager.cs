using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Interfaces
{
    internal interface IRegisterManager
    {
        IReadOnlyList<IPlayer> CreatePlayers(IPlayerRegisterManager playerRegisterManager);

        IPlayer ChooseFirstPlayer();

        int GetBoardSize();
    }
}

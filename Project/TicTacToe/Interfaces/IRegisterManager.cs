using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Interfaces
{
    internal interface IRegisterManager
    {
        IReadOnlyList<IPlayer> CreatePlayers(int playersCount, IPlayerRegisterManager playerRegisterManager);

        IPlayer ChooseFirstPlayer();

        int GetBoardSize();
    }
}

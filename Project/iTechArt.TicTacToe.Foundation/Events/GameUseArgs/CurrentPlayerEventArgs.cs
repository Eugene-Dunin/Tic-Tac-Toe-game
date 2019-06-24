using System;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Players;

namespace iTechArt.TicTacToe.Foundation.Events.GameUseArgs
{
    public class CurrentPlayerEventArgs : EventArgs
    {
        public IPlayer CurrentPlayer { get; }

        public CurrentPlayerEventArgs(IPlayer currentPlayer)
        {
            CurrentPlayer = currentPlayer;
        }
    }

}
using System;

namespace iTechArt.TicTacToe.Foundation.GameLogic.Finish
{
    public abstract  class FinishedEventArgs : EventArgs
    {
        public abstract GameResult Result { get; }
    }
}
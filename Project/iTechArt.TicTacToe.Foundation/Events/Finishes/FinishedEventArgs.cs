using System;
using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Events.GameUseArgs;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Events.Finishes
{
    public abstract  class FinishedEventArgs : EventArgs
    {
        public abstract GameResult Result { get; }
    }
}
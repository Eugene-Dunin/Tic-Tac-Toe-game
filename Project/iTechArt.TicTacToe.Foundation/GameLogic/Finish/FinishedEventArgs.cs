using System;

namespace iTechArt.TicTacToe.Foundation.GameLogic.Finish
{
    public abstract  class FinishedEventArgs : EventArgs
    {
        public GameResult Result { get; }


        protected FinishedEventArgs(GameResult result)
        {
            Result = result;
        }
    }
}
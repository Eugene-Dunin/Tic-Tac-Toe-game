using System;

namespace iTechArt.TicTacToe.Foundation.GameLogic.StepDone
{
    public abstract class StepDoneEventArgs : EventArgs
    {
        public StepResult Result { get; }

        protected StepDoneEventArgs(StepResult result)
        {
            Result = result;
        }
    }
}
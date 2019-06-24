using System;

namespace iTechArt.TicTacToe.Foundation.Events.Steps
{
    public abstract class StepDoneEventArgs : EventArgs
    {
        public abstract StepResult Result { get; }
    }
}
using System;
using iTechArt.TicTacToe.Foundation.Events.Finishes;
using iTechArt.TicTacToe.Foundation.Events.Steps;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGame
    {
        event EventHandler<FinishedEventArgs> Finished;

        event EventHandler<StepDoneEventArgs> StepDone;

        void Start();
    }
}
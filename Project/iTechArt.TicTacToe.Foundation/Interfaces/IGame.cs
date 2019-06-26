using System;
using iTechArt.TicTacToe.Foundation.GameLogic.Finish;
using iTechArt.TicTacToe.Foundation.GameLogic.StepDone;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGame
    {
        event EventHandler<FinishedEventArgs> Finished;

        event EventHandler<StepDoneEventArgs> StepDone;


        void Start();
    }
}
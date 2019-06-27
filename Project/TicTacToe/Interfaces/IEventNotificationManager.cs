using iTechArt.TicTacToe.Foundation.GameLogic.Finish;
using iTechArt.TicTacToe.Foundation.GameLogic.StepDone;

namespace iTechArt.TicTacToe.Interfaces
{
    internal interface IEventNotificationManager
    {
        void ShowWinner(FinishedEventArgs gameFinishedEventArgs);
        void ShowStepDoneMessage(StepDoneEventArgs stepFailedEventArgs);
    }
}
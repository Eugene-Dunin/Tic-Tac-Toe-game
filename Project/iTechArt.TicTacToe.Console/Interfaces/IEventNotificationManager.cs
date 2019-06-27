using iTechArt.TicTacToe.Foundation.GameLogic.Finish;
using iTechArt.TicTacToe.Foundation.GameLogic.StepDone;

namespace iTechArt.TicTacToe.Console.Interfaces
{
    public interface IEventNotificationManager
    {
        void ShowWinner(FinishedEventArgs gameFinishedEventArgs);
        void ShowStepDoneMessage(StepDoneEventArgs stepFailedEventArgs);
    }
}
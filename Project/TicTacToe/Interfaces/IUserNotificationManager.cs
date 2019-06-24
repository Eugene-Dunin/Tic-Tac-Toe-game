using iTechArt.TicTacToe.Foundation.Events.GameUseArgs;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Interfaces
{
    internal interface IUserNotificationManager
    {
        void ShowFigureTypes(IFigureManager figureManager);
        void ShowWinner(GameFinishedEventArgs gameFinishedEventArgs);
        void ShowStepFailedMessage(StepFailedEventArgs stepFailedEventArgs);
        void ShowCurrentPlayer(IPlayer player);
        void ShowFigureTypeChooseError(string figureName);
    }
}
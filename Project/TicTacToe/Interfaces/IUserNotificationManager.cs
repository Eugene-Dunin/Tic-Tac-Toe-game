﻿using iTechArt.TicTacToe.Foundation.Events.Finishes;
using iTechArt.TicTacToe.Foundation.Events.Steps;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Interfaces
{
    internal interface IUserNotificationManager
    {
        void ShowFigureTypes(IFigureManager figureManager);
        void ShowWinner(FinishedEventArgs gameFinishedEventArgs);
        void ShowStepDoneMessage(StepDoneEventArgs stepFailedEventArgs);
        void ShowCurrentPlayer(IPlayer player);
        void ShowFigureTypeChooseError(string figureName);
    }
}
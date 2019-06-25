using System;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Events.Finishes;
using iTechArt.TicTacToe.Foundation.Events.GameUseArgs;
using iTechArt.TicTacToe.Foundation.Events.Steps;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Interfaces;

namespace iTechArt.TicTacToe.NotificationManagers
{
    internal class NotificationManager : IUserNotificationManager
    {
        public void ShowFigureTypes(IFigureManager figureManager)
        {
            Console.WriteLine("Figures that allowed for game:");
            figureManager.AllFigureTypes.ToList().ForEach(type => Console.WriteLine(nameof(type)));
        }

        public void ShowWinner(FinishedEventArgs gameFinishedEventArgs)
        {
            switch (gameFinishedEventArgs.Result)
            {
                case GameResult.Draw:
                    Console.WriteLine("Game result: Draw");
                    break;
                case GameResult.Win:
                    var result = (WinFinishedEventArgs) gameFinishedEventArgs;
                    Console.WriteLine("Game result: Win");
                    Console.WriteLine("Win line have next cells:");
                    result.WinLine.Cells.ToList().ForEach
                        (cell => Console.WriteLine($"[{cell.Row}, {cell.Column}]"));
                    Console.WriteLine();
                    break;
            }
        }

        public void ShowStepDoneMessage(StepDoneEventArgs stepDoneEventArgs)
        {
            switch (stepDoneEventArgs.Result)
            {
                case StepResult.CellNotExist:
                    Console.WriteLine("Selected cell is not exist.");
                    break;
                case StepResult.CellIsFilled:
                    var cell = ((StepForbiddenEventArgs)stepDoneEventArgs).FilledCell;
                    Console.WriteLine($"Cell on [{cell.Row}, {cell.Column}] filled by {nameof(cell.Figure.Type)}");
                    break;
            }
        }

        public void ShowCurrentPlayer(IPlayer player)
        {
            Console.WriteLine(player.ToString());
        }

        public void ShowFigureTypeChooseError(string figureName)
        {
            Console.WriteLine($"{figureName} there is no figure with this name.");
        }
    }
}
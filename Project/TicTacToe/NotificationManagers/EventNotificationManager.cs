using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.GameLogic.Finish;
using iTechArt.TicTacToe.Foundation.GameLogic.StepDone;
using iTechArt.TicTacToe.Interfaces;

namespace iTechArt.TicTacToe.NotificationManagers
{
    internal class EventNotificationManager : IEventNotificationManager
    {
        private readonly IConsoleInputProvider _consoleInputProvider;

        public EventNotificationManager(IConsoleInputProvider consoleInputProvider)
        {
            _consoleInputProvider = consoleInputProvider;
        }

        public void ShowWinner(FinishedEventArgs gameFinishedEventArgs)
        {
            switch (gameFinishedEventArgs.Result)
            {
                case GameResult.Draw:
                    _consoleInputProvider.Console.WriteLine("Game result: Draw");
                    break;
                case GameResult.Win:
                    var result = (WinFinishedEventArgs) gameFinishedEventArgs;
                    _consoleInputProvider.Console.WriteLine("Game result: Win");
                    _consoleInputProvider.Console.WriteLine("Win line have next cells:");
                    /*result.WinLine.Cells.ToList().ForEach
                        (cell => _consoleInputProvider.Console.WriteLine($"[{cell.Row}, {cell.Column}]"));*/
                    _consoleInputProvider.Console.WriteLine();
                    break;
            }
        }

        public void ShowStepDoneMessage(StepDoneEventArgs stepDoneEventArgs)
        {
            switch (stepDoneEventArgs.Result)
            {
                case StepResult.CellNotExist:
                    _consoleInputProvider.Console.WriteLine("Selected cell is not exist.");
                    break;
                case StepResult.CellIsFilled:
                    var cell = ((CellIsFilledStepDoneEventArgs)stepDoneEventArgs).FilledCell;
                    _consoleInputProvider.Console.WriteLine($"Cell on [{cell.Row}, {cell.Column}] filled by {nameof(cell.Figure.Type)}");
                    break;
            }
        }
    }
}
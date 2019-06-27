using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.GameLogic.Finish;
using iTechArt.TicTacToe.Foundation.GameLogic.StepDone;
using iTechArt.TicTacToe.Interfaces;

namespace iTechArt.TicTacToe.NotificationManagers
{
    internal class EventNotificationManager : IEventNotificationManager
    {
        private readonly IConsole _console;


        public EventNotificationManager(IConsole console)
        {
            _console = console;
        }


        public void ShowWinner(FinishedEventArgs gameFinishedEventArgs)
        {
            switch (gameFinishedEventArgs.Result)
            {
                case GameResult.Draw:
                    _console.WriteLine("Game result: Draw");
                    break;
                case GameResult.Win:
                    var result = (WinFinishedEventArgs) gameFinishedEventArgs;
                    _console.WriteLine("Game result: Win");
                    _console.WriteLine("Win line have next cells:");
                    /*result.WinLine.Cells.ToList().ForEach
                        (cell => _console.WriteLine($"[{cell.Row}, {cell.Column}]"));*/
                    _console.WriteLine();
                    break;
            }
        }

        public void ShowStepDoneMessage(StepDoneEventArgs stepDoneEventArgs)
        {
            switch (stepDoneEventArgs.Result)
            {
                case StepResult.CellNotExist:
                    _console.WriteLine("Selected cell is not exist.");
                    break;
                case StepResult.CellIsFilled:
                    var cell = ((CellIsFilledStepDoneEventArgs)stepDoneEventArgs).FilledCell;
                    _console.WriteLine($"Cell on [{cell.Row}, {cell.Column}] filled by {nameof(cell.Figure.Type)}");
                    break;
            }
        }
    }
}
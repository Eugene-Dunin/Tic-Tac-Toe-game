using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.GameInputProviders
{
    public class GameInputProvider : IGameInputProvider
    {
        private readonly IConsole _console;
        private readonly IConsoleInputProvider _inputProvider;


        public GameInputProvider(IConsoleInputProvider inputProvider, IConsole console)
        {
            _inputProvider = inputProvider;
            _console = console;
        }


        public  (int row, int col) GetCellCoordinates(IPlayer player)
        {
            _console.WriteLine($"Current player: {player.Name} {player.LastName}. Figure: {player.FigureType}");
            (int row, int col) coordinates;
            coordinates.row = _inputProvider.GetNumber("Input row number:");
            coordinates.col = _inputProvider.GetNumber("Input column number:");

            return coordinates;
        }
    }
}
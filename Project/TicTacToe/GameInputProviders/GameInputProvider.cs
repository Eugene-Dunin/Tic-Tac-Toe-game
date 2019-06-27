using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.GameInputProviders
{
    internal class GameInputProvider : IGameInputProvider
    {
        private readonly IConsoleInputProvider _inputProvider;


        public GameInputProvider(IConsoleInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }


        public  (int row, int col) GetCellCoordinates(IPlayer player)
        {
            _inputProvider.Console.WriteLine($"Current player: {player.Name} {player.LastName}. Figure: {player.FigureType}");
            (int row, int col) coordinates;
            coordinates.row = _inputProvider.GetNumber("Input row number:");
            coordinates.col = _inputProvider.GetNumber("Input column number:");
            return coordinates;
        }
    }
}
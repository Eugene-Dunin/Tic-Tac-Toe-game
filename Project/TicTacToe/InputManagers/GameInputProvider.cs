using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.InputManagers
{
    internal class InputProvider : IGameInputProvider
    {
        private readonly IConsoleInputProvider _inputProvider;


        public InputProvider(IConsoleInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }


        public  (int row, int col) GetCellCoordinates(IPlayer player)
        {
            (int row, int col) coordinates;
            coordinates.row = _inputProvider.GetNumber("Input row number:");
            coordinates.col = _inputProvider.GetNumber("Input column number:");
            return coordinates;
        }


        protected override void SetPlayerInfo()
        {
            do
            {
                if (!int.TryParse(Console.ReadLine(), out age))
                {
                    Console.WriteLine("Incorrect age, it must be a number. Try again.");
                    continue;
                }
                name = Console.ReadLine();
                lastname = Console.ReadLine();
                return;
            } while (true);
        }
    }
}
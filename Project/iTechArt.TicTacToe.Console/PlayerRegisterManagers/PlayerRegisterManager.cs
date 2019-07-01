using System.Collections.Generic;
using iTechArt.TicTacToe.Console.Extensions;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Players;

namespace iTechArt.TicTacToe.Console.PlayerRegisterManagers
{
    public class PlayerRegisterManager : IPlayerRegisterManager
    {
        private readonly IConsole _console;
        private readonly IConsoleInputProvider _inputProvider;


        public PlayerRegisterManager(IConsoleInputProvider inputProvider, IConsole console)
        {
            _inputProvider = inputProvider;
            _console = console;
        }


        public IPlayer Register(IReadOnlyList<FigureType> availableFigureTypes)
        {
            var name = _inputProvider.GetString("Input you name","Name can not be empty.");
            var lastName = _inputProvider.GetString("Input you lastname", "Lastname can not be empty.");
            var figureType = GetFigureType(availableFigureTypes);
            return new Player(name, lastName, figureType);
        }


        private FigureType GetFigureType(IReadOnlyList<FigureType> availableFigureTypes)
        {
            _console.WriteLine("Allowed figure types:");
            availableFigureTypes.ForEach(
                (allowedFigureType, index) => _console.WriteLine($"{index + 1}) {allowedFigureType.ToString()}"));
            do
            {
                var figureNumber = _inputProvider.GetNumber("Input number of chosen figure.");
                if (figureNumber >= 1 && figureNumber <= availableFigureTypes.Count)
                {
                    return availableFigureTypes[figureNumber - 1];
                }
                _console.WriteLine("There is not figure type with that name.");
            } while (true);
        }
    }
}
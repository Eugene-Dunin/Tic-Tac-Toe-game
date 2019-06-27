using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Players;
using iTechArt.TicTacToe.Interfaces;

namespace iTechArt.TicTacToe.PlayerRegisterManagers
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


        public IPlayer Register(IReadOnlyList<FigureType> figureTypes)
        {
            var name = _inputProvider.GetString("Input you name","Name can not be empty.");
            var lastName = _inputProvider.GetString("Input you lastname", "Lastname can not be empty.");
            var figureType = GetFigureType(figureTypes);
            return new Player(name, lastName, figureType);
        }


        private FigureType GetFigureType(IReadOnlyList<FigureType> figureTypes)
        {
            _console.WriteLine("Allowed figure types:");
            figureTypes.ToList().ForEach(allowedFigureType => _console.WriteLine(allowedFigureType.ToString()));
            do
            {
                var figureTypeName = _inputProvider.GetString("Input name of chosen figure.", "Name can not be empty.");
                var resultFigureType = figureTypes.SingleOrDefault(figureType => nameof(figureType).Equals(figureTypeName));
                if (nameof(resultFigureType).Equals(figureTypeName))
                {
                    return resultFigureType;
                }
                _console.WriteLine("There is not figure type with that name.");
            } while (true);
        }
    }
}
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
        private readonly IConsoleInputProvider _inputProvider;

        public PlayerRegisterManager(IConsoleInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public IPlayer Register(IReadOnlyList<FigureType> figureTypes)
        {
            var name = _inputProvider.GetString();
            var lastName = _inputProvider.GetString();
            var figureType = GetFigureType(figureTypes);
            return new Player(name, lastName, figureType);
        }

        private FigureType GetFigureType(IReadOnlyList<FigureType> figureTypes)
        {
            _inputProvider.Console.WriteLine("Allowed figure types:");
            figureTypes.ToList().ForEach(allowedFigureType => _inputProvider.Console.WriteLine(allowedFigureType.ToString()));
            do
            {
                var figureTypeName = _inputProvider.GetString();
                var resultFigureType = figureTypes.SingleOrDefault(figureType => nameof(figureType).Equals(figureTypeName));
                if (nameof(resultFigureType).Equals(figureTypeName))
                {
                    return resultFigureType;
                }
                _inputProvider.Console.WriteLine("There is not figure type with that name.");
            } while (true);
        }
    }
}
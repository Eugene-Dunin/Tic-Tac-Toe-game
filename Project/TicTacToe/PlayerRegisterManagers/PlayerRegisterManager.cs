using System;
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
        private readonly IReadOnlyList<FigureType> _figureTypesSet;

        private List<FigureType> _allowedFigureTypes;


        public PlayerRegisterManager(IConsoleInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
            _figureTypesSet = ((FigureType[])Enum.GetValues(typeof(FigureType))).ToList();
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
                var figureType = PopFigureType(_inputProvider.GetString());
                if (figureType.HasValue)
                {
                    return figureType.Value;
                }
            } while (true);
        }

        private FigureType PopFigureType(string figureTypeName)
        {
            return _allowedFigureTypes.SingleOrDefault(figureType => nameof(figureType).Equals(figureTypeName));
        }
    }
}
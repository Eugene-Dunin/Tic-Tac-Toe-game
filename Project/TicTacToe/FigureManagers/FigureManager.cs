using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Interfaces;

namespace iTechArt.TicTacToe.FigureManagers
{
    internal class FigureManager : IFigureManager
    {
        private readonly HashSet<FigureType> _figureTypes;


        public IReadOnlyCollection<FigureType> AllFigureTypes => _figureTypes;

        public int CurrentAllowedCountOfPlayers => _figureTypes.Count;


        public FigureManager(HashSet<FigureType> figureTypes)
        {
            _figureTypes = figureTypes;
        }


        public FigureType? PopFigureType(string figureTypeName)
        {
            var requiredFigureType = _figureTypes.First(figureType => nameof(figureType).Equals(figureTypeName));
            _figureTypes.Remove(requiredFigureType);
            return requiredFigureType;
        }
    }
}
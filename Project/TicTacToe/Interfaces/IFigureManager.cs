using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Interfaces
{
    internal interface IFigureManager
    {
        IReadOnlyCollection<FigureType> AllFigureTypes { get; }

        int CurrentAllowedCountOfPlayers { get; }

        FigureType? PopFigureType(string figureTypeName);
    }
}
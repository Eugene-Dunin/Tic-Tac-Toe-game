using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Interfaces
{
    internal interface IFigureManager
    {
        IReadOnlyCollection<FigureType> AllFigureTypes { get; }

        int CurrentAllowedCountOfPlayers { get; }

        FigureType? PopFigureType(FigureType figureType);
    }
}

using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Interfaces
{
    internal interface IPlayerRegisterManager
    {
        IPlayer Register(IReadOnlyList<FigureType> figureTypes);
    }
}
using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.Interfaces
{
    public interface IPlayerRegisterManager
    {
        IPlayer Register(IReadOnlyList<FigureType> availableFigureTypes);
    }
}
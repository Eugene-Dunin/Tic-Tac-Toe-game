using System.Collections.Generic;
using iTechArt.TicTacToe.Console.FigureDrawers;

namespace iTechArt.TicTacToe.Console.Interfaces
{
    public interface IFigureDrawersFactory
    {
        IReadOnlyList<FigureDrawerBase> CreateFigureDrawers();
    }
}
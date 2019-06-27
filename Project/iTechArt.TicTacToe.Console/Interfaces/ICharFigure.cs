using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.Interfaces
{
    public interface ICharFigure : IFigure 
    {
        char FigureSymbol { get; }
    }
}
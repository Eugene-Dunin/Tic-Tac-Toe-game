using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Interfaces
{
    interface ICharFigure : IFigure 
    {
        char FigureSymbol { get; }
    }
}
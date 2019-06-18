using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IFigureFactory
    {
        IFigure CreateFigure(FigureType figureType);
    }
}

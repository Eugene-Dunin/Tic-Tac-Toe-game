using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }

        string LastName { get; }

        FigureType FigureType { get; }
    }
}
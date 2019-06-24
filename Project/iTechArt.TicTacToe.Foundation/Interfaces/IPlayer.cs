using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IPlayer
    {
        int Age { get; }

        string Name { get; }

        string LastName { get; }

        FigureType FigureType { get; }
    }
}
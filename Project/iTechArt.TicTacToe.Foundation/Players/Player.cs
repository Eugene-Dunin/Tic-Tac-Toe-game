using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Foundation.Players
{
    public class Player : IPlayer
    {
        public string Name { get; private set; }

        public string LastName { get; private set; }

        public FigureType FigureType { get; }


        public Player(string name, string lastName, FigureType figureType)
        {
            Name = name;
            LastName = lastName;
            FigureType = figureType;
        }
    }
}
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Foundation.Players
{
    public class Player : IPlayer
    {
        private int age;


        public string Name { get; private set; }

        public string LastName { get; private set; }

        public int Age {
            get => age;
            private set {
                if(value >= AgeConstraints.MinAge 
                   && value < AgeConstraints.MaxAge)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException(
                        $"Age of player should between {AgeConstraints.MinAge} - {AgeConstraints.MaxAge}"
                    );
                }
            }
        }


        public FigureType FigureType { get; }


        public Player(string name, string lastName, int age, FigureType figureType)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            FigureType = figureType;
        }
    }
}
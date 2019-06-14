using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Player
{
    public class Player
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
                        String.Format("Age of player should between {0} - {1}",
                            AgeConstraints.MinAge, AgeConstraints.MaxAge)
                    );
                }
            }
        }


        public Player(string name, string lastName, int age)
        {
            Name = name;
            LastName = lastName;
            Age = age;
        }
    }
}

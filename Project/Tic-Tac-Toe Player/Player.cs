﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Player
{
    public class Player
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }

        private int age;
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
<<<<<<< HEAD

        public static class AgeConstraints
        {
            public const int MinAge = 3;
            public const int MaxAge = 120;
        }
=======
>>>>>>> b3515b2062d73b8bf110195b385a37500084e28c
    }
}

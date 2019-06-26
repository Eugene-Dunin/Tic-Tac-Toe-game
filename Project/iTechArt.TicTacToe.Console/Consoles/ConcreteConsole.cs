using iTechArt.TicTacToe.Console.Interfaces;
using System;

namespace iTechArt.TicTacToe.Console.Consoles
{
    public class ConcreteConsole : IConsole
    {
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }

        public void Write(string value)
        {
            System.Console.Write(value);
        }

        public void WriteLine(string value)
        {
            System.Console.WriteLine(value);
        }
    }
}
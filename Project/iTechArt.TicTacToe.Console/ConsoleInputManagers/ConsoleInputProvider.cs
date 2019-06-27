using System;
using iTechArt.TicTacToe.Console.Interfaces;

namespace iTechArt.TicTacToe.Console.ConsoleInputManagers
{
    public class ConsoleInputProvider : IConsoleInputProvider
    {
        public IConsole Console { get; }


        public ConsoleInputProvider(IConsole console)
        {
            Console = console;
        }


        public int GetNumber(string initialMessage, string errorMessage)
        {
            Console.WriteLine(initialMessage);
            do
            {
                if (Int32.TryParse(Console.ReadLine(), out var value))
                {
                    return value;
                }
                Console.WriteLine(errorMessage);
            } while (true);
        }

        public string GetString(string initialMessage, string errorMessage)
        {
            Console.WriteLine(initialMessage);
            do
            {
                var value = Console.ReadLine();
                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }
                Console.WriteLine(errorMessage);
            } while (true);
        }

        public bool Prompt(string initialMessage, string errorMessage)
        {
            Console.WriteLine(initialMessage);
            do
            {
                var answer = Console.ReadLine()?.ToUpper();
                switch (answer)
                {
                    case "YES":
                        return true;
                    case "NO":
                        return false;
                    default:
                        Console.WriteLine(errorMessage);
                        break;
                }
            } while (true);
        }
    }
}
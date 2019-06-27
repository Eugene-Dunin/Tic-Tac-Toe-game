﻿using iTechArt.TicTacToe.Console.Interfaces;

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
                if (int.TryParse(Console.ReadLine(), out var value))
                {
                    return value;
                }
                Console.WriteLine(errorMessage);
            } while (true);
        }

        public string GetString()
        {
            return Console.ReadLine();
        }

        public bool YesNoQuestion(string initialMessage, string errorMessage)
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
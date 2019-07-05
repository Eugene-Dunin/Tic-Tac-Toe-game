using System;
using iTechArt.TicTacToe.Console.Interfaces;

namespace iTechArt.TicTacToe.Console.ConsoleInputManagers
{
    public class ConsoleInputProvider : IConsoleInputProvider
    {
        private readonly IConsole _console;


        public ConsoleInputProvider(IConsole console)
        {
            _console = console;
        }


        public int GetNumber(string initialMessage, string errorMessage)
        {
            _console.WriteLine(initialMessage);
            do
            {
                if (Int32.TryParse(_console.ReadLine(), out var value))
                {
                    return value;
                }
                _console.WriteLine(errorMessage);
            } while (true);
        }

        public string GetString(string initialMessage, string errorMessage)
        {
            _console.WriteLine(initialMessage);
            do
            {
                var value = _console.ReadLine();
                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }
                _console.WriteLine(errorMessage);
            } while (true);
        }

        public bool Prompt(string initialMessage, string errorMessage)
        {
            _console.WriteLine(initialMessage);
            do
            {
                var answer = _console.ReadLine()?.ToUpper();
                switch (answer)
                {
                    case "YES":
                        return true;
                    case "NO":
                        return false;
                    default:
                        _console.WriteLine(errorMessage);
                        break;
                }
            } while (true);
        }
    }
}
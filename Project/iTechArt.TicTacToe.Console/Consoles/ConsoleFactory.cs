using iTechArt.TicTacToe.Console.Interfaces;

namespace iTechArt.TicTacToe.Console.Consoles
{
    public class ConsoleFactory : IConsoleFactory
    {
        public IConsole CreateConsole()
        {
            return new ConcreteConsole();
        }
    }
}
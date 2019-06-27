using iTechArt.TicTacToe.Console.Interfaces;

namespace iTechArt.TicTacToe.Console.ConsoleInputManagers
{
    public class ConsoleInputProviderFactory : IConsoleInputProviderFactory
    {
        public IConsoleInputProvider CreateConsoleInputManager(IConsoleFactory consoleFactory)
        {
            return new ConsoleInputProvider(consoleFactory.CreateConsole());
        }
    }
}
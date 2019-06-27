namespace iTechArt.TicTacToe.Console.Interfaces
{
    public interface IConsoleInputProviderFactory
    {
        IConsoleInputProvider CreateConsoleInputManager(IConsoleFactory consoleFactory);
    }
}
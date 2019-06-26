namespace iTechArt.TicTacToe.Console.Interfaces
{
    public interface IConsoleInputProvider
    {
        IConsole Console { get; }

        int GetNumber(string initialMessage, string errorMessage = "Is not a number.");

        string GetString();

        bool YesNoQuestion(string initialMessage, string errorMessage);
    }
}
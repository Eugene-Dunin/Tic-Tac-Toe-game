namespace iTechArt.TicTacToe.Console.Interfaces
{
    public interface IConsoleInputProvider
    {
        int GetNumber(string initialMessage, string errorMessage = "Is not a number.");

        string GetString(string initialMessage, string errorMessage);

        bool Prompt(string initialMessage, string errorMessage);
    }
}
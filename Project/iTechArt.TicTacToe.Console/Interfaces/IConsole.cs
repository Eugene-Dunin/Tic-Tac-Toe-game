namespace iTechArt.TicTacToe.Console.Interfaces
{
    public interface IConsole
    {
        string ReadLine();

        void Write(string value);

        void WriteLine(string value);
    }
}
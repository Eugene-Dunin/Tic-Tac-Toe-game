namespace iTechArt.TicTacToe.Foundation.GameLogic.Finish
{
    public class WinFinishedEventArgs : FinishedEventArgs
    {
        public WinFinishedEventArgs()
            : base(GameResult.Win)
        {

        }
    }
}
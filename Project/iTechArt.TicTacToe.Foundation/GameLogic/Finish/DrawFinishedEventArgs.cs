namespace iTechArt.TicTacToe.Foundation.GameLogic.Finish
{
    public class DrawFinishedEventArgs : FinishedEventArgs
    {
        public DrawFinishedEventArgs()
            : base(GameResult.Draw)
        {

        }
    }
}
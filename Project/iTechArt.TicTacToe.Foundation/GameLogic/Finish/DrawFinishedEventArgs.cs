namespace iTechArt.TicTacToe.Foundation.GameLogic.Finish
{
    public class DrawFinishedEventArgs : FinishedEventArgs
    {
        public override GameResult Result => GameResult.Draw;
    }
}
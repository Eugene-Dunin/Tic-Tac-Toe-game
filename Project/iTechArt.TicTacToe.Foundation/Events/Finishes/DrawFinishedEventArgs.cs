using iTechArt.TicTacToe.Foundation.Events.GameUseArgs;

namespace iTechArt.TicTacToe.Foundation.Events.Finishes
{
    public class DrawFinishedEventArgs : FinishedEventArgs
    {
        public override GameResult Result => GameResult.Draw;
    }
}
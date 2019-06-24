using iTechArt.TicTacToe.Foundation.Events.GameUseArgs;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Events.Finishes
{
    public class WinFinishedEventArgs : FinishedEventArgs
    {
        public override GameResult Result => GameResult.Win;

        public ILine WinLine { get; }


        public WinFinishedEventArgs(ILine winLine)
        {
            WinLine = winLine;
        }
    }
}
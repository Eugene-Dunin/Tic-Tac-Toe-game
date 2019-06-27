using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.GameLogic.Finish
{
    public class WinFinishedEventArgs : FinishedEventArgs
    {
        public ILine WinLine { get; }


        public WinFinishedEventArgs(ILine winLine)
            : base(GameResult.Win)
        {
            WinLine = winLine;
        }
    }
}
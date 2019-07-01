using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.GameLogic.Finish
{
    public class WinFinishedEventArgs : FinishedEventArgs
    {
        public ILine WinLine { get; }

        public IPlayer WinPlayer { get; }


        public WinFinishedEventArgs(ILine winLine, IPlayer winPlayer)
            : base(GameResult.Win)
        {
            WinLine = winLine;
            WinPlayer = winPlayer;
        }
    }
}
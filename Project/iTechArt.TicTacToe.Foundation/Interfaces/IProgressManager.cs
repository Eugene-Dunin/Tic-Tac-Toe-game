using System;
using iTechArt.TicTacToe.Foundation.Events.GameUseArgs;

namespace iTechArt.TicTacToe.Foundation.GameLogic
{
    public interface IProgressManager
    {
        EventHandler<GameFinishedEventArgs> Finished { get; set; }

        void CalcGameProgress();
    }
}

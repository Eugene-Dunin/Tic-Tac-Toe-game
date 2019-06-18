using System;
using iTechArt.TicTacToe.Foundation.Events.DependenceOfGameArgs;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IInGameDependenceEvents
    {
        event EventHandler<FillCellEventArgs> FillCellEvent;
    }
}

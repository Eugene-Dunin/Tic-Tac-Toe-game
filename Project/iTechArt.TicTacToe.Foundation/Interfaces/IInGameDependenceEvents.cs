using iTechArt.TicTacToe.Foundation.Events.UIToGameArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IInGameDependenceEvents
    {
        event EventHandler<RegisterEventArgs> RegisterEvent;
        event EventHandler<EventArgs> RepeatGameEvent;
        event EventHandler<FillCellEventArgs> FillCellEvent;
    }
}

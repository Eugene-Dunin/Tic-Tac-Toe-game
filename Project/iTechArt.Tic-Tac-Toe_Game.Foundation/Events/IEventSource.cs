using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Game.Foundation.Events
{
    public interface IEventSource<T> where T : EventArgs
    {
        event EventHandler<T> EventReccipientsKeeper;
        void OnEventHappend(T e);
    }
}

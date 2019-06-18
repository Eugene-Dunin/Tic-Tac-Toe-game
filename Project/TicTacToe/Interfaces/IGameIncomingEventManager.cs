using iTechArt.TicTacToe.Foundation.Events.GameToUIArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Interfaces
{
    interface IGameIncomingEventManager
    {
        void OnGameNotification(object sender, GameNotificationEventArgs args);
        void OnGameStepFinished(object sender, GameStepFinishedEventArgs args);
        void OnGameFinished(object sender, GameFinishedEventArgs args);
    }
}

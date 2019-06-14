using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Events.GameToUIArgs
{
    public class GameNotificationEventArgs : EventArgs
    {
        public string[] NotificationMessages { get; }


        public GameNotificationEventArgs(params string[] notificationMessages)
        {
            NotificationMessages = notificationMessages;
        }
    }
}

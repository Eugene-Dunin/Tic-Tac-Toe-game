using System;

namespace iTechArt.TicTacToe.Foundation.Events.GameUseArgs
{
    public class NotificationEventArgs : EventArgs
    {
        public string[] NotificationMessages { get; }


        public NotificationEventArgs(params string[] notificationMessages)
        {
            NotificationMessages = notificationMessages;
        }
    }
}

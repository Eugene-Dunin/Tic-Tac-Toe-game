using System;

namespace iTechArt.TicTacToe.Foundation.Events.GameUseArgs
{
    public class StepFailedEventArgs : EventArgs
    {
        public string Message { get; }


        public StepFailedEventArgs(string message)
        {
            Message = message;
        }
    }
}

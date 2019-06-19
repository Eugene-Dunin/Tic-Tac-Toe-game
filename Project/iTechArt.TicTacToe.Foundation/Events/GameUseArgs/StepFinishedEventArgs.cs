using System;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Events.GameUseArgs
{
    public class StepFinishedEventArgs : EventArgs
    {
        public IBoard Board { get; }


        public StepFinishedEventArgs(IBoard board)
        {
            Board = board;
        }
    }
}
using System;

namespace iTechArt.TicTacToe.Foundation.Events.DependenceOfGameArgs
{
    public class FillCellEventArgs : EventArgs
    {
        public int Row { get; }

        public int Column { get; }

        public FillCellEventArgs(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
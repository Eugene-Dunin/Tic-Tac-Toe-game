using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Events.UIToGameArgs
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

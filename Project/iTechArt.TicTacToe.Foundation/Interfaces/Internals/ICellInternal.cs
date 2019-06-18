using iTechArt.TicTacToe.Foundation.GameBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Interfaces.Internals
{
    internal interface ICellInternal : ICell
    {
        new IFigure Figure { set; }
    }
}

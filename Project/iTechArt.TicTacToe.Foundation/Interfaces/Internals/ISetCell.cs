using iTechArt.TicTacToe.Foundation.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Interfaces.Internals
{
    interface ISetCell : ICell
    {
        void SetFigure(IFigure figure);
    }
}

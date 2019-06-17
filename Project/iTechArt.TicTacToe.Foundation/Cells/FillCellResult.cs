using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Cells
{
    public enum FillCellResult
    {
        Successful,
        Forbidden,
        Occupied,
        NullBoard,
        NullFigure,
        NotContain
    }
}

using iTechArt.TicTacToe.Foundation.Cells;
using iTechArt.TicTacToe.Foundation.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IBoard : IEnumerable<ICell>
    {
        IReadOnlyList<ICell> Cells { get; }

        FillCellResult FillCell(FigureType figureType, int row, int column);
    }
}

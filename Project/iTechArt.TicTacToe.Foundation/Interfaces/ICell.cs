using iTechArt.TicTacToe.Foundation.Cells;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface ICell
    {
        IFigure Figure { get; }

        bool IsEmpty { get; }

        int Row { get; }

        int Column { get; }

        FillCellResult SetFigure(Func<IBoard> getBoard, IFigure figure);
    }
}

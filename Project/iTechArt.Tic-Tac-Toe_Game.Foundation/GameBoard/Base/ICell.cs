using iTechArt.TicTacToe.Foundation.Figures.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.GameBoard.Base
{
    public interface ICell
    {
        IFigure Figure { get; set; }

        FigureType GetStoredFigureType { get; }

        int Row { get; }

        int Column { get; }
    }
}

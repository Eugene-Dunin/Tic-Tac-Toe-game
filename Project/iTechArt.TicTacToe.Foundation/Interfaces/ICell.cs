using iTechArt.Tic_Tac_Toe_Game.Foundation.Cells;
using iTechArt.Tic_Tac_Toe_Game.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures.Base;
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

        FillCellResult SetFigure(IBoard board, IFigure figure);
    }
}

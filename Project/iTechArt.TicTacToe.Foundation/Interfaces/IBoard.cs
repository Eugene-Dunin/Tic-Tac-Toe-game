using iTechArt.TicTacToe.Foundation.Figures.Base;
using iTechArt.TicTacToe.Foundation.GameBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IBoard: IEnumerable<ICell>
    {
        FillBoardCellResult FillBoardCell(FigureType figure, int row, int column);
    }
}

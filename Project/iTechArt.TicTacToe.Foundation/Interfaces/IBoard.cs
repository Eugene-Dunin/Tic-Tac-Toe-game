using iTechArt.TicTacToe.Foundation.GameBoard;
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
        int MatrixSize { get; }

        ICell this[int row, int column] { get; }
    }
}

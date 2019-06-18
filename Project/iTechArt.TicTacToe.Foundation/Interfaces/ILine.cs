using iTechArt.TicTacToe.Foundation.Lines;
using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface ILine
    {
        IEnumerable<ICell> Cells { get; }

        LineState State { get; }
    }
}

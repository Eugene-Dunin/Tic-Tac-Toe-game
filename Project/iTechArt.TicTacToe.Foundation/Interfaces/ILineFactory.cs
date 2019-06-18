using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface ILineFactory
    {
        ILine CreateLine(IEnumerable<ICell> cells);
    }
}

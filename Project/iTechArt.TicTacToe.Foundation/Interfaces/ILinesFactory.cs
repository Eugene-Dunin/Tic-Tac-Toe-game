using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Lines;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface ILinesFactory
    {
        IReadOnlyList<BaseLine> CreateLines(IBoard board);
    }
}
using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Base;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface ILinesFactory
    {
        IReadOnlyList<BaseLine> CreateLines(IBoard board);
    }
}
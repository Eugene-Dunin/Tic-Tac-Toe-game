using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface ILinesFactory
    {
        IReadOnlyList<ILine> CreateLines(IBoard board);
    }
}
using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface ILine
    {
        IReadOnlyList<ICell> Cells { get; }

        bool IsWin { get; }
    }
}
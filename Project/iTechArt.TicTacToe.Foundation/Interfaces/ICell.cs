using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface ICell : IEqualityComparer<bool>
    {
        IFigure Figure { get; }

        bool IsEmpty { get; }

        int Row { get; }

        int Column { get; }
    }
}
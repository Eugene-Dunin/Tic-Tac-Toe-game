using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IBoard : IEnumerable<ICell>
    {
        int Size { get; }

        ICell this[int row, int column] { get; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameInputProvider
    {
        (int row, int col) GetCellCoordinates(IPlayer player);
    }
}

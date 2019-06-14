using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Tic_Tac_Toe_Game.Foundation.Interfaces
{
    public interface ICellFactory
    {
        ICell GetCell(int row, int column);
    }
}

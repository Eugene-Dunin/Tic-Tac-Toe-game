using iTechArt.Tic_Tac_Toe_Game.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.GameBoard;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Tic_Tac_Toe_Game.Foundation.GameBoard
{
    public class CellFactory : ICellFactory
    {
        public ICell GetCell(int row, int column)
        {
            return new Cell(row, column);
        }
    }
}

using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Cells
{
    public class CellFactory : ICellFactory
    {
        public ICell CreateCell(int row, int column)
        {
            return new Cell(row, column);
        }
    }
}

using iTechArt.TicTacToe.Foundation.Interfaces;

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
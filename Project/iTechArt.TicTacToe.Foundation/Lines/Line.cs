using iTechArt.TicTacToe.Foundation.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    public sealed class Line : ILine
    {
        public IEnumerable<ICell> Cells { get; }


        public LineState State {
            get
            {
                var filledCells = Cells.Where(cell => cell.Figure != null);
                var enumerable = filledCells.ToList();

                if (enumerable.Any(cell => cell.Figure.Type != enumerable.First().Figure.Type))
                {
                    return LineState.Standoff;
                }

                return enumerable.Count == Cells.Count() ? LineState.Winning : LineState.Progress;
            }
        }


        public Line(IEnumerable<ICell> cells)
        {
            Cells = cells;
        }
    }
}

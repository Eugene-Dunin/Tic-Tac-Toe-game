using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    class Line : ILine
    {
        private IReadOnlyList<ICell> cells;


        public IFigure WinningFigure { get; private set; }


        public LineState State { get; private set; }


        public Line(IEnumerable<ICell> cells)
        {
            cells = cells ?? throw new NullReferenceException();
            State = LineState.Progress;
        }


        public void CalcLineProgress()
        {
            if (State == LineState.Progress)
            {
                if (cells.All(cell => cell.Figure.Type == cells.First().Figure.Type))
                {
                    WinningFigure = cells.First().Figure;
                }
            }
        }
    }
}

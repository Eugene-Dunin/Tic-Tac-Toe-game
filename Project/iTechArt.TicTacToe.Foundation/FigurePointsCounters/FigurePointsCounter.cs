using iTechArt.TicTacToe.Foundation.FigurePointsCounters;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Interfaces.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Progress
{
    public class FigurePointsCounter : IFigurePointsIncrement
    {
        public FigureType Type { get; }
        public int NumberOfPoints { get; private set; }

        public void IncrementPoints()
        {
            NumberOfPoints++;
        }

        public FigurePointsCounter(FigureType figureType)
        {
            Type = figureType;
            NumberOfPoints = 0;
        }
    }
}

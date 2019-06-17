using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Progress
{
    public class FigurePointsProgress : IFigurePointsCounter
    {
        public FigureType Type { get; }
        public int NumberOfPoints { get; private set; }
        public void IncrementPoints()
        {
            NumberOfPoints++;
        }

        public FigurePointsProgress(FigureType figureType)
        {
            Type = figureType;
            NumberOfPoints = 0;
        }
    }
}

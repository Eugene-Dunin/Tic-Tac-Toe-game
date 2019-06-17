using iTechArt.TicTacToe.Foundation.FigurePointsCounters;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Progress
{
    public class FigurePointsCounter : IFigurePointsCounter
    {
        public FigureType Type { get; }
        public int NumberOfPoints { get; private set; }

        public IncrementPointsResult IncrementPoints(Func<BaseProgressManager> getProgressManager)
        {
            if (getProgressManager != null 
                && getProgressManager.Target is BaseProgressManager
                && getProgressManager().ContainsFigurePointsCounters(this))
            {
                NumberOfPoints++;

                return IncrementPointsResult.Successful;
            }

            return IncrementPointsResult.Forbidden;
        }

        public FigurePointsCounter(FigureType figureType)
        {
            Type = figureType;
            NumberOfPoints = 0;
        }
    }
}

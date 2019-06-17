using iTechArt.TicTacToe.Foundation.FigurePointsCounters;
using iTechArt.TicTacToe.Foundation.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IFigurePointsCounter
    {
        FigureType Type { get; }
        int NumberOfPoints { get; }
    }
}

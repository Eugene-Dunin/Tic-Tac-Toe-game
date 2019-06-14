using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Figures.Base
{
    public interface IFigure
    {
        FigureType GetFigureType { get; }
    }
}

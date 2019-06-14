using iTechArt.TicTacToe.Foundation.Figures.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Figures
{
    class Cross : IFigure
    {
        public FigureType GetFigureType => FigureType.Cross;
    }
}

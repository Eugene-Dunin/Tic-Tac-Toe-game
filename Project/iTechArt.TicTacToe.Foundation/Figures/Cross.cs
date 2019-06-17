using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Figures
{
    public class Cross : IFigure
    {
        public FigureType Type => FigureType.Cross;
    }
}

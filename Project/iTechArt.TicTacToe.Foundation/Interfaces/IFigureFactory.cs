using iTechArt.TicTacToe.Foundation.Cells;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IFigureFactory
    {
        IFigure GreateFigure(FigureType figureType);
    }
}

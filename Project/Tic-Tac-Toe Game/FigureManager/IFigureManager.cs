using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Figure;

namespace Tic_Tac_Toe_Game.FigureManager
{
    interface IFigureManager
    {
        Figure GetFigure(FigureManagerMode figureManagerMode);
    }
}

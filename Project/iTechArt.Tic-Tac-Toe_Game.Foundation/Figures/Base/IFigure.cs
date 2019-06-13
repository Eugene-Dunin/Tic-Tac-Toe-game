using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Tic_Tac_Toe_Game.Foundation.Figures
{
    public interface IFigure
    {
        FigureType GetFigureType { get; }
    }
}

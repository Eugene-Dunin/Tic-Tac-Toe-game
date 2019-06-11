using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Game.FigureManager
{
    enum FigureManagerMode
    {
        Random, Choose
    }

    interface IFigureManagerModeChoose
    {
        FigureManagerMode GetMode();
    }
}

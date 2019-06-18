using iTechArt.TicTacToe.Foundation.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Interfaces
{
    interface IUserNotificationManager
    {
        FigureType ChooseFigure(IEnumerable<FigureType> figureTypes);
    }
}

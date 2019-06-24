using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArt.TicTacToe.FigureManagers;
using iTechArt.TicTacToe.InputManagers;
using iTechArt.TicTacToe.Interfaces;

namespace TicTacToe.Interfaces
{
    interface IBaseUserInputManagerFactory
    {
        BaseInputManager CreateBaseUserInputManager(IUserNotificationManager userNotificationManager);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Base;

namespace TicTacToe.Interfaces
{
    interface IBaseUserInputManagerFactory
    {
        BaseUserInputManager CreateBaseUserInputManager(IUserNotificationManager userNotificationManager);
    }
}

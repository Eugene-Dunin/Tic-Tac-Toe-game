using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Game.Events;
using Tic_Tac_Toe_Player;

namespace Tic_Tac_Toe_Game.Notification
{
    interface INotificationManager
    {
        void ShowActivePlayer(Player player);
        void ShowGameResults(GameFinishedEventArgs gameFinishedEventArgs);
    }
}

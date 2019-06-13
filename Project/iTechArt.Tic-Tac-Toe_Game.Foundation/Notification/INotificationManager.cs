using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Game.Events;
using Tic_Tac_Toe_Game.Foundation.Figures;
using Tic_Tac_Toe_Player;

namespace Tic_Tac_Toe_Game.Notification
{
    public interface INotificationManager
    {
        void ShowActivePlayer(KeyValuePair<Player, Figure> player);
        void ShowGameResults(GameFinishedEventArgs gameFinishedEventArgs);
        void DisplayMessage(string message);
    }
}

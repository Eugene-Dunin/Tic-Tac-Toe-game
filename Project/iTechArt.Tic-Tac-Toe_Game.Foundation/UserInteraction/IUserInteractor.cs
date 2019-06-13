using iTechArt.Tic_Tac_Toe_Game.Foundation.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Game.Events;
using Tic_Tac_Toe_Game.Foundation.Events;
using Tic_Tac_Toe_Game.Foundation.GameLogic;
using Tic_Tac_Toe_Player;

namespace Tic_Tac_Toe_Game
{
    public interface IUserInteractor
    {
        Player CreatePlayer(IMessageNotification messageNotification);
        int SetPlayersCount(IMessageNotification messageNotification);
        int SetGameGridSize(IMessageNotification messageNotification);
        bool RepeatGame(IMessageNotification messageNotification);
        CellCoordinates GetCellCoordinates(IMessageNotification messageNotification);
    }
}

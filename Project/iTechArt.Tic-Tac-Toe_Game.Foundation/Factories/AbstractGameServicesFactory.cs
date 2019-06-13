using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Game.FigureManager;
using Tic_Tac_Toe_Game.Foundation.Display;
using Tic_Tac_Toe_Game.Foundation.GameLogic;
using Tic_Tac_Toe_Game.Foundation.PlayersDataManager;
using Tic_Tac_Toe_Game.Notification;

namespace Tic_Tac_Toe_Game.Foundation.Factories
{
    public abstract class AbstractGameServicesFactory
    {
        public abstract IPlayersDataManager GetPlayersDataManager(int playersCount);
        public abstract IUserInteractor GetUserInteractor();
        public abstract INotificationManager GetNotificationManager();
        public abstract IFigureManager GetFigureManager();
        public abstract IGameBoardDisplay GameBoardDisplay();
        public abstract IGameBoardStorage GetGameBoard();
        public abstract IGameProgressManager GetGameProgressManager();
    }
}

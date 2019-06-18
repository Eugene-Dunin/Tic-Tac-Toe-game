using iTechArt.TicTacToe.Base;
using iTechArt.TicTacToe.Foundation.Events.UIToGameArgs;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;

namespace TicTacToe.Base
{
    abstract class BaseUserInputManager
    {
        private IUserNotificationManager userNotificationManager;

        protected BaseUserInputManager(IUserNotificationManager userNotificationManager)
        {
            this.userNotificationManager = userNotificationManager;
        }

        public Player RegisterNewPlayer(BaseFigureManager figuremanager)
        {
            SetPlayerInfo();
            var figureType = userNotificationManager.ChooseFigure(figuremanager.AllFigureTypes);
            return CreatePlayer(figuremanager.GetFigure(figureType));
        }


        protected abstract void SetPlayerInfo();

        protected abstract Player CreatePlayer(IFigure figure);

        public abstract Player ChooseFirstPlayer(IEnumerable<Player> players);

        public abstract FillCellEventArgs ChooseCell();

        public abstract bool RepeatGame();
    }
}

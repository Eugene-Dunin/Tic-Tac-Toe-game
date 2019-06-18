using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArt.TicTacToe.Base;
using iTechArt.TicTacToe.Foundation.Events.GameToUIArgs;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Players;
using TicTacToe.Base;
using TicTacToe.Interfaces;

namespace TicTacToe.Implementation
{
    class GameProcessManager
    {
        private List<Player> players; 

        private IBoardDraw boardDraw;

        private BaseUserInputManager userInputManager;

        private IUserNotificationManager userNotificationManager;

        private BaseFigureManager figuremanager;


        public GameProcessManager(
            IBoardDraw boardDraw,
            IBaseUserInputManagerFactory userInputManagerFactory,
            IUserNotificationManagerFactory userNotificationManagerFactory,
            BaseFigureManager figuremanager)
        {
            this.boardDraw = boardDraw;
            userNotificationManager = userNotificationManagerFactory.CreateUserNotificManager();
            userInputManager = userInputManagerFactory.CreateBaseUserInputManager(userNotificationManager);
            this.figuremanager = figuremanager;
            players = new List<Player>();
        }

        public void Register()
        {
            while(figuremanager.CurrentAllowedCountOfPlayers != 0)
            {
                players.Add(userInputManager.RegisterNewPlayer(figuremanager));
            }
            var firstPlayer = userInputManager.ChooseFirstPlayer(players);
            players.Remove(firstPlayer);
            players.Insert(0, firstPlayer);
        }


        private void OnGameFinished(object sender, GameFinishedEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void OnGameNotification(object sender, GameNotificationEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void OnGameStepFinished(object sender, GameStepFinishedEventArgs args)
        {
            boardDraw.Draw(args);
        }
    }
}

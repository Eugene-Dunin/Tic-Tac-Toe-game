using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Game.Events;
using Tic_Tac_Toe_Game.FigureManager;
using Tic_Tac_Toe_Game.Foundation.Display;
using Tic_Tac_Toe_Game.Foundation.Factories;
using Tic_Tac_Toe_Game.Foundation.Figures;
using Tic_Tac_Toe_Game.Foundation.GameLogic;
using Tic_Tac_Toe_Game.Foundation.PlayersDataManager;
using Tic_Tac_Toe_Game.Notification;
using Tic_Tac_Toe_Player;

namespace Tic_Tac_Toe_Game
{
    public class Game
    {
        private readonly string INUNIQUE_PLAYER_NOTIFICATION_MESSAGE = "This player alredy exists.";

        private IPlayersDataManager playersDataManager;
        private IUserInteractor userInteractor;
        private INotificationManager notificationManager;
        private IFigureManager figureManager;
        private IGameBoardDisplay gameBoardDisplay;
        private IGameBoardStorage gameBoardStorage;
        private IGameProgressManager gameProgressManager;

        private AbstractGameServicesFactory gameServicesFactory;
        private bool isGameFinished;

        public Game(AbstractGameServicesFactory gameServicesFactory)
        {
            this.gameServicesFactory = gameServicesFactory;

            userInteractor = gameServicesFactory.GetUserInteractor();
            notificationManager = gameServicesFactory.GetNotificationManager();
            figureManager = gameServicesFactory.GetFigureManager();
            gameBoardStorage = gameServicesFactory.GetGameBoard();

            gameProgressManager = gameServicesFactory.GetGameProgressManager();
            gameProgressManager.EventReccipientsKeeper += OnGameFinished;

            isGameFinished = false;
        }

        public void Start()
        {
            do
            {
                RegisterPlayers();
                Gaming();

                while (userInteractor.RepeatGame())
                {
                    gameBoardStorage.ClearGameBoard();
                    Gaming();
                }
            }
            while (true);
        }

        private void RegisterPlayers()
        {
            int playersCount = userInteractor.SetPlayersCount();
            playersDataManager = gameServicesFactory.GetPlayersDataManager(playersCount);
            Player player;
            for (int playerNum = 1; playerNum <= playersCount; playerNum++)
            {
                player = userInteractor.CreatePlayer();
                if (playersDataManager.IsUniquePlayer(player))
                {
                    playersDataManager.Add(player, figureManager.GetFigure());
                }
                else
                {
                    notificationManager.DisplayMessage(INUNIQUE_PLAYER_NOTIFICATION_MESSAGE);
                }
            }
        }

        private void Gaming()
        {
            foreach (var playerData in playersDataManager.GetNextPlayer(isGameFinished))
            {
                notificationManager.ShowActivePlayer(playerData);
                DoStep(playerData.Value);
            }
        }

        private void DoStep(Figure figure)
        {
            bool isStepSucceed = false;

            do
            {
                try
                {
                    gameBoardStorage.FillCell(figure, userInteractor.GetCellCoordinates());
                    isStepSucceed = true;
                }
                catch (InvalidCastException ex)
                {
                    notificationManager.DisplayMessage(ex.Message);
                }
            }
            while (!isStepSucceed);

            var gridData = gameBoardStorage.GetCellsData();
            gameBoardDisplay.DrawGameBoard(gridData);
            gameProgressManager.CalcGameProgress(gridData);
        }

        private void OnGameFinished(object sender, GameFinishedEventArgs e)
        {
            notificationManager.ShowGameResults(e);
            isGameFinished = true;
        }
    }
}

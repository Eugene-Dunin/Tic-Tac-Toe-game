using iTechArt.TicTacToe.Foundation.Events.GameToUIArgs;
using iTechArt.TicTacToe.Foundation.Events.UIToGameArgs;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iTechArt.TicTacToe.Foundation.GameLogic
{
    public class Game
    {
        private const string BuildObjectExceptionMessage = "All parameters of constructor should have value.";

        private PlayersDataManager playersDataManager;

        private IFigureManager figureManager;

        private IBoard gameBoardStorage;

        private Interfaces.BaseProgressManager gameProgressManager;

        private bool isGameFinished;

        private StepArgs stepArgs;


        public EventHandler<GameFinishedEventArgs> GameFinishedEvent;


        public EventHandler<GameStepFinishedEventArgs> GameStepEvent;


        public EventHandler<GameNotificationEventArgs> GameNotificationEvent;


        public EventHandler<EventArgs> GetCellCoordinatesEvent;

        public Game(PlayersDataManager playersDataManager,
            IFigureManager figureManager,
            IBoard gameBoardStorage,
            Interfaces.BaseProgressManager gameProgressManager,
            IInGameDependenceEvents inGameDependenceEvents)
        {
            this.playersDataManager = playersDataManager ?? throw new NullReferenceException(BuildObjectExceptionMessage);

            this.figureManager = figureManager ?? throw new NullReferenceException(BuildObjectExceptionMessage); ;

            this.gameBoardStorage = gameBoardStorage ?? throw new NullReferenceException(BuildObjectExceptionMessage); ;

            this.gameProgressManager = gameProgressManager ?? throw new NullReferenceException(BuildObjectExceptionMessage);

            this.gameProgressManager.GameFinished += OnGameFinished;

            if (inGameDependenceEvents != null)
            {
                inGameDependenceEvents.RegisterEvent += RegisterNewGame;
                inGameDependenceEvents.RepeatGameEvent += RepeatGame;
                inGameDependenceEvents.FillCellEvent += TryDoStep;
            }
            else
            {
                throw new NullReferenceException(BuildObjectExceptionMessage);
            }

            isGameFinished = false;

            stepArgs = new StepArgs();
        }

        private void RegisterNewGame(object sender, RegisterEventArgs registerEventArgs)
        {
            RegisterPlayers(registerEventArgs);
            Gaming();
        }

        private void RepeatGame(object sender, EventArgs repeatGameEventArgs)
        {
            if (isGameFinished)
            {
                gameBoardStorage.ClearGameBoard();
                isGameFinished = false;
                Gaming();
            }
            else
            {
                throw new InvalidOperationException("The game has no data about the previous game.");
            }
        }

        private void RegisterPlayers(RegisterEventArgs registerEventArgs)
        {
            foreach (var player in registerEventArgs.Players)
            {
                playersDataManager.Add(player, figureManager.GetFigure());
            }
        }


        private void Gaming()
        {
            foreach (var playerData in playersDataManager.GetNextPlayer(isGameFinished))
            {
                GameNotificationEvent?.Invoke(this,
                    new GameNotificationEventArgs(
                        playerData.Value.ToString(), playerData.Key.ToString())
                );
                DoStep(playerData.Value);
            }
        }


        private void DoStep(IFigure figure)
        {
            stepArgs.Figure = figure;
            stepArgs.IsStepSucceed = false;
            do
            {
                GetCellCoordinatesEvent?.Invoke(this, null);
            }
            while (!stepArgs.IsStepSucceed);

            GameStepEvent?.Invoke(this, new GameStepFinishedEventArgs(gameBoardStorage.GetCellsData()));
            gameProgressManager.CalcGameProgress(gameBoardStorage);
        }


        private void TryDoStep(object sender, FillCellEventArgs fillCellEventArgs)
        {
            try
            {
                gameBoardStorage.FillCell(stepArgs.Figure, fillCellEventArgs.Row, fillCellEventArgs.Column);
                stepArgs.IsStepSucceed = true;
            }
            catch (InvalidCastException ex)
            {
                GameNotificationEvent?.Invoke(this, new GameNotificationEventArgs(ex.Message));
            }
        }


        private void OnGameFinished(object sender, GameFinishedEventArgs e)
        {
            GameFinishedEvent?.Invoke(this, e);
            isGameFinished = true;
        }



        private struct StepArgs
        {
            public bool IsStepSucceed { get; set; }

            public IFigure Figure { get; set; }
        }
    }
}

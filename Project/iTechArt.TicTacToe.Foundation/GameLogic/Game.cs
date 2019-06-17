using iTechArt.TicTacToe.Foundation.Base;
using iTechArt.TicTacToe.Foundation.Cells;
using iTechArt.TicTacToe.Foundation.Events.GameToUIArgs;
using iTechArt.TicTacToe.Foundation.Events.UIToGameArgs;
using iTechArt.TicTacToe.Foundation.Figures;
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
        private IGameConfigManagerFactory gameConfigManagerFactory;

        private BaseGameConfigManager gameConfigManager;

        private bool isGameFinished;

        private StepArgs stepArgs;


        public EventHandler<GameFinishedEventArgs> GameFinishedEvent;


        public EventHandler<GameStepFinishedEventArgs> GameStepEvent;


        public EventHandler<GameNotificationEventArgs> GameNotificationEvent;


        public EventHandler<EventArgs> GetCellCoordinatesEvent;


        public Game(
            IGameConfigManagerFactory gameConfigManagerFactory,
            IInGameDependenceEvents inGameDependenceEvents)
        {
            this.gameConfigManagerFactory = gameConfigManagerFactory;

            gameConfigManager = gameConfigManagerFactory.CreateBaseGameConfigManager();

            gameConfigManager.ProgressManager.GameFinished += OnGameFinished;

            inGameDependenceEvents.FillCellEvent += TryDoStep;

            isGameFinished = false;

            stepArgs = new StepArgs();
        }

        public void StartOrRepeat()
        {
            if (isGameFinished)
            {
                gameConfigManager = gameConfigManagerFactory.CreateBaseGameConfigManager();
                isGameFinished = false;
            }
            Gaming();
        }


        private void Gaming()
        {
            foreach (var player in gameConfigManager.GetNextPlayer(isGameFinished))
            {
                GameNotificationEvent?.Invoke(this,
                    new GameNotificationEventArgs(
                        player.Figure.ToString(), player.ToString())
                );
                DoStep(player.Figure.Type);
            }
        }


        private void DoStep(FigureType figureType)
        {
            stepArgs.FigureType = figureType;
            stepArgs.IsStepSucceed = false;
            do
            {
                GetCellCoordinatesEvent?.Invoke(this, null);
            }
            while (!stepArgs.IsStepSucceed);

            GameStepEvent?.Invoke(this, new GameStepFinishedEventArgs(gameConfigManager.Board.AsEnumerable()));
            gameConfigManager.ProgressManager.CalcGameProgress();
        }


        private void TryDoStep(object sender, FillCellEventArgs fillCellEventArgs)
        {
            var fillResult = gameConfigManager.Board.FillCell(stepArgs.FigureType, fillCellEventArgs.Row, fillCellEventArgs.Column);
            switch (fillResult)
            {
                case FillCellResult.Successful:
                    {
                        gameConfigManager.Board.FillCell(stepArgs.FigureType, fillCellEventArgs.Row, fillCellEventArgs.Column);
                        stepArgs.IsStepSucceed = true;
                        break;
                    }
                case FillCellResult.Occupied:
                    {
                        GameNotificationEvent?.Invoke(this, new GameNotificationEventArgs(nameof(FillCellResult.Occupied)));
                        break;
                    }
                case FillCellResult.BoardNotContain:
                    {
                        GameNotificationEvent?.Invoke(this, new GameNotificationEventArgs(nameof(FillCellResult.BoardNotContain)));
                        break;
                    }
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

            public FigureType FigureType { get; set; }
        }
    }
}

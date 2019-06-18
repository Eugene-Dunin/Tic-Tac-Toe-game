using iTechArt.TicTacToe.Foundation.Base;
using iTechArt.TicTacToe.Foundation.Cells;
using iTechArt.TicTacToe.Foundation.Events.GameToUIArgs;
using iTechArt.TicTacToe.Foundation.Events.UIToGameArgs;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Players;
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

        private IBoardFactory boardFactory;

        private IProgressManagerFactory progressManagerFactory;

        private IGameConfig gameConfig;

        private IBoard board;

        private BaseProgressManager progressManager;

        private bool isGameFinished;

        private StepArgs stepArgs;


        public EventHandler<GameFinishedEventArgs> GameFinishedEvent;


        public EventHandler<GameStepFinishedEventArgs> GameStepEvent;


        public EventHandler<GameNotificationEventArgs> GameNotificationEvent;


        public EventHandler<EventArgs> GetCellCoordinatesEvent;


        public Game(
            IGameConfig gameConfigManager,
            IBoardFactory boardFactory,
            IProgressManagerFactory progressManagerFactory,
            IInGameDependenceEvents inGameDependenceEvents)
        {
            this.gameConfig = gameConfigManager;

            this.boardFactory = boardFactory;

            this.progressManagerFactory = progressManagerFactory;

            InitGameServices();

            progressManager.GameFinished += OnGameFinished;

            inGameDependenceEvents.FillCellEvent += TryDoStep;

            isGameFinished = false;

            stepArgs = new StepArgs();
        }


        private void InitGameServices()
        {
            board = boardFactory.CreateBoard(gameConfig.BoardSize);
            progressManager = progressManagerFactory.CreateProgressManager(board);
        }

        public void StartOrRepeat()
        {
            if (isGameFinished)
            {
                InitGameServices();
                isGameFinished = false;
            }
            Gaming();
        }


        private void Gaming()
        {
            var enumerator = gameConfig.Players.AsEnumerable().GetEnumerator();
            Player player;

            while(!isGameFinished)
            {
                if (enumerator.MoveNext())
                {
                    player = enumerator.Current;

                    GameNotificationEvent?.Invoke(this,
                    new GameNotificationEventArgs(
                       player.Figure.ToString(), player.ToString())
                    );
                    DoStep(player.Figure.Type);
                }
                else
                {
                    enumerator.Reset();
                }
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

            GameStepEvent?.Invoke(this, new GameStepFinishedEventArgs(board.AsEnumerable()));
            progressManager.CalcGameProgress();
        }


        private void TryDoStep(object sender, FillCellEventArgs fillCellEventArgs)
        {
            var fillResult = board.FillCell(stepArgs.FigureType, fillCellEventArgs.Row, fillCellEventArgs.Column);
            switch (fillResult)
            {
                case FillCellResult.Successful:
                    {
                        board.FillCell(stepArgs.FigureType, fillCellEventArgs.Row, fillCellEventArgs.Column);
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

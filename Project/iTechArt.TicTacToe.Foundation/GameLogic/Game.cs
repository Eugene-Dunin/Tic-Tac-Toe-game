using iTechArt.TicTacToe.Foundation.GameBoard;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Events.DependenceOfGameArgs;
using iTechArt.TicTacToe.Foundation.Events.GameUseArgs;
using iTechArt.TicTacToe.Foundation.Interfaces.Internals;


namespace iTechArt.TicTacToe.Foundation.GameLogic
{
    public class Game
    {
        private IGameConfigManagerFactory gameConfigManagerFactory;

        private IBoardFactory boardFactory;

        private IProgressManagerFactory progressManagerFactory;

        private IGameConfig gameConfig;

        private IBoardInternal board;

        private IProgressManager progressManager;

        private bool isGameFinished;

        private StepArgs stepArgs;


        public EventHandler<GameFinishedEventArgs> GameFinishedEvent;


        public EventHandler<StepFinishedEventArgs> GameStepEvent;


        public EventHandler<NotificationEventArgs> GameNotificationEvent;


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

            progressManager.Finished += OnGameFinished;

            inGameDependenceEvents.FillCellEvent += TryDoStep;

            isGameFinished = false;

            stepArgs = new StepArgs();
        }


        private void InitGameServices()
        {
            board = (IBoardInternal)boardFactory.CreateBoard(gameConfig.BoardSize);
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

            while(!isGameFinished)
            {
                if (enumerator.MoveNext())
                {
                    var player = enumerator.Current;

                    GameNotificationEvent?.Invoke(this,
                    new NotificationEventArgs(
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

            GameStepEvent?.Invoke(this, new StepFinishedEventArgs(board));
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
                case FillCellResult.CellOccupied:
                    {
                        GameNotificationEvent?.Invoke(this, new NotificationEventArgs(nameof(FillCellResult.CellOccupied)));
                        break;
                    }
                case FillCellResult.CellNotFound:
                    {
                        GameNotificationEvent?.Invoke(this, new NotificationEventArgs(nameof(FillCellResult.CellNotFound)));
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

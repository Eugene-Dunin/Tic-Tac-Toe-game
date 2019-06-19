using iTechArt.TicTacToe.Foundation.GameBoard;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Base;
using iTechArt.TicTacToe.Foundation.Events.DependenceOfGameArgs;
using iTechArt.TicTacToe.Foundation.Events.GameUseArgs;
using iTechArt.TicTacToe.Foundation.Interfaces.Internals;

namespace iTechArt.TicTacToe.Foundation.GameLogic
{
    public class Game
    {
        private IGameConfig _gameConfig;
        private IReadOnlyList<BaseLine> _lines;
        private IBoardInternal _board;
        private StepArgs _stepArgs;


        private bool IsGameFinished => _lines.Any(line => line.IsWin);


        public EventHandler<GameFinishedEventArgs> GameFinishedEvent;

        public EventHandler<StepFinishedEventArgs> GameStepEvent;

        public EventHandler<NotificationEventArgs> GameNotificationEvent;

        public EventHandler<EventArgs> GetCellCoordinatesEvent;


        public Game(
            IGameConfig gameConfig,
            IBoardFactory boardFactory,
            IInGameDependenceEvents inGameDependenceEvents)
        {
            _gameConfig = gameConfig;

            _board = (IBoardInternal)boardFactory.CreateBoard(gameConfig.BoardSize);

            inGameDependenceEvents.FillCellEvent += TryDoStep;

            _stepArgs = new StepArgs();
        }


        public void Start()
        {
            var enumerator = _gameConfig.Players.AsEnumerable().GetEnumerator();

            while(IsGameFinished)
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
            EmitGameFinishedEvent();
        }


        private void DoStep(FigureType figureType)
        {
            _stepArgs.FigureType = figureType;
            _stepArgs.IsStepSucceed = false;
            do
            {
                GetCellCoordinatesEvent?.Invoke(this, null);
            }
            while (!_stepArgs.IsStepSucceed);

            GameStepEvent?.Invoke(this, new StepFinishedEventArgs(_board));
        }

        private void TryDoStep(object sender, FillCellEventArgs fillCellEventArgs)
        {
            var fillResult = _board.FillCell(_stepArgs.FigureType, fillCellEventArgs.Row, fillCellEventArgs.Column);
            switch (fillResult)
            {
                case FillCellResult.Successful:
                    {
                        _board.FillCell(_stepArgs.FigureType, fillCellEventArgs.Row, fillCellEventArgs.Column);
                        _stepArgs.IsStepSucceed = true;
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

        private void EmitGameFinishedEvent()
        {
            var gameFinishedEventArgs = _lines.Count == 0
                ? new GameFinishedEventArgs(GameResult.Win, _lines)
                : new GameFinishedEventArgs(GameResult.Draw, _lines);
            GameFinishedEvent?.Invoke(this, gameFinishedEventArgs);
        }



        private struct StepArgs
        {
            public bool IsStepSucceed { get; set; }

            public FigureType FigureType { get; set; }
        }
    }
}
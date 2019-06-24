using iTechArt.TicTacToe.Foundation.GameBoard;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Events.GameUseArgs;
using iTechArt.TicTacToe.Foundation.Interfaces.Internals;

namespace iTechArt.TicTacToe.Foundation.GameLogic
{
    public class Game
    {
        private readonly IGameConfig _gameConfig;
        private readonly IReadOnlyList<ILine> _lines;
        private readonly IBoardInternal _board;
        private readonly IGameInputProvider _gameInputProvider;


        private bool IsGameFinished => _lines.Any(line => line.IsWin) || _board.All(cell => !cell.IsEmpty);


        public EventHandler<GameFinishedEventArgs> GameFinishedEvent;

        public EventHandler<StepFailedEventArgs> StepFailedEvent;


        public Game(
            IGameConfig gameConfig,
            IBoardFactory boardFactory,
            IFigureFactory figureFactory,
            ICellFactory cellFactory,
            ILinesFactory linesFactory,
            IGameInputProvider gameInputProvider            )
        {
            _gameConfig = gameConfig;
            _gameInputProvider = gameInputProvider;

            _board = (IBoardInternal)boardFactory.CreateBoard(gameConfig.BoardSize, figureFactory, cellFactory);

            _lines = linesFactory.CreateLines(_board);
        }


        public void Start()
        {
            using (var enumerator = _gameConfig.Players.AsEnumerable().GetEnumerator())
            {
                while (enumerator.MoveNext() && enumerator.Current != _gameConfig.FirstPlayer){}

                while (IsGameFinished)
                {
                    var player = enumerator.Current;
                    DoStep(player);

                    if (!enumerator.MoveNext())
                    {
                        enumerator.Reset();
                    }
                }

                EmitGameFinishedEvent();
            }
        }


        private void DoStep(IPlayer player)
        {
            FillCellResult fillResult;
            do
            {
                var (row, col) = _gameInputProvider.GetCellCoordinates(player);
                fillResult = _board.FillCell(player.FigureType, row, col);

                switch (fillResult)
                {
                    case FillCellResult.Successful:
                        break;
                    case FillCellResult.CellOccupied:
                    {
                        StepFailedEvent?.Invoke(this, new StepFailedEventArgs(nameof(FillCellResult.CellOccupied)));
                        break;
                    }
                    case FillCellResult.CellNotFound:
                    {
                        StepFailedEvent?.Invoke(this, new StepFailedEventArgs(nameof(FillCellResult.CellNotFound)));
                        break;
                    }
                }

            } while (fillResult != FillCellResult.Successful);
        }

        private void EmitGameFinishedEvent()
        {
            var gameFinishedEventArgs = _lines.Any(line => line.IsWin)
                ? new GameFinishedEventArgs(GameResult.Win, _lines)
                : new GameFinishedEventArgs(GameResult.Draw, _lines);
            GameFinishedEvent?.Invoke(this, gameFinishedEventArgs);
        }
    }
}
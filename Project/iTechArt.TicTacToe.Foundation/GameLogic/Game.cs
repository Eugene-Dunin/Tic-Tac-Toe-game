using iTechArt.TicTacToe.Foundation.GameBoard;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Events.Finishes;
using iTechArt.TicTacToe.Foundation.Events.Steps;
using iTechArt.TicTacToe.Foundation.Interfaces.Internals;

namespace iTechArt.TicTacToe.Foundation.GameLogic
{
    public class Game : IGame
    {
        private readonly IGameConfig _gameConfig;
        private readonly IGameInputProvider _gameInputProvider;

        private readonly IBoardInternal _board;
        private readonly IReadOnlyList<ILine> _lines;


        private bool IsGameFinished => _lines.Any(line => line.IsWin) || _board.All(cell => !cell.IsEmpty);

        public event EventHandler<FinishedEventArgs> Finished;

        public event EventHandler<StepDoneEventArgs> StepDone;


        public Game(
            IGameConfig gameConfig,
            IBoardFactory boardFactory,
            ILinesFactory linesFactory,
            IGameInputProvider gameInputProvider)
        {
            _gameConfig = gameConfig;
            _gameInputProvider = gameInputProvider;

            _board = (IBoardInternal)boardFactory.CreateBoard(gameConfig.BoardSize);

            _lines = linesFactory.CreateLines(_board);
        }


        public void Start()
        {
            var index = _gameConfig.Players.ToList().IndexOf(_gameConfig.FirstPlayer);
            while (!IsGameFinished)
            {
                var player = _gameConfig.Players.ElementAt(index);
                DoStep(player);

                index = index < _gameConfig.Players.Count ? index + 1 : 0;
            }
            EmitGameFinishedEvent();
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
                        StepDone?.Invoke(this, new StepFinishedEventArgs(_board));
                        break;
                    case FillCellResult.CellOccupied:
                        StepDone?.Invoke(this, new StepForbiddenEventArgs(_board[row, col]));
                        break;
                    case FillCellResult.CellNotFound:
                        StepDone?.Invoke(this, new StepImpossibleEventArgs());
                        break;
                }

            } while (fillResult != FillCellResult.Successful);
        }

        private void EmitGameFinishedEvent()
        {
            FinishedEventArgs gameFinishedEventArgs;

            if (_lines.Any(line => line.IsWin))
            {
                gameFinishedEventArgs = new WinFinishedEventArgs(_lines.First(line => line.IsWin));
            }
            else
            {
                gameFinishedEventArgs = new DrawFinishedEventArgs();
            }

            Finished?.Invoke(this, gameFinishedEventArgs);
        }
    }
}
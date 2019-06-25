using iTechArt.TicTacToe.Foundation.GameBoard;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.GameLogic.Finish;
using iTechArt.TicTacToe.Foundation.GameLogic.StepDone;
using iTechArt.TicTacToe.Foundation.Interfaces.Internals;

namespace iTechArt.TicTacToe.Foundation.GameLogic
{
    public class Game : IGame
    {
        private readonly IGameInputProvider _gameInputProvider;

        private readonly IBoardInternal _board;
        private readonly IReadOnlyList<ILine> _lines;
        private readonly IReadOnlyList<IPlayer> _players;
        private int currentPlayerIndex;


        private bool IsGameFinished => _lines.Any(line => line.IsWin) || _board.All(cell => !cell.IsEmpty);

        private IPlayer CurrentPlayer => _players.ElementAt(currentPlayerIndex);


        public event EventHandler<FinishedEventArgs> Finished;

        public event EventHandler<StepDoneEventArgs> StepDone;


        public Game(
            IGameConfig gameConfig,
            IBoardFactory boardFactory,
            ILinesFactory linesFactory,
            IGameInputProvider gameInputProvider)
        {
            _gameInputProvider = gameInputProvider;

            _board = (IBoardInternal)boardFactory.CreateBoard(gameConfig.BoardSize);

            _lines = linesFactory.CreateLines(_board);

            currentPlayerIndex = gameConfig.Players.ToList().IndexOf(gameConfig.FirstPlayer);
            _players = gameConfig.Players;
        }


        public void Start()
        {
            while (!IsGameFinished)
            {
                DoStep(CurrentPlayer);
                currentPlayerIndex = ++currentPlayerIndex % _players.Count;
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
                        StepDone?.Invoke(this, new SuccessfulStepDoneEventArgs(_board));
                        break;
                    case FillCellResult.CellOccupied:
                        StepDone?.Invoke(this, new CellIsFilledStepDoneEventArgs(_board[row, col]));
                        break;
                    case FillCellResult.CellNotFound:
                        StepDone?.Invoke(this, new CellNotExistStepDoneEventArgs());
                        break;
                }

            } while (fillResult != FillCellResult.Successful);
        }

        private void EmitGameFinishedEvent()
        {
            var gameFinishedEventArgs = _lines.Any(line => line.IsWin)
                ? (FinishedEventArgs)new WinFinishedEventArgs(_lines.First(line => line.IsWin))
                : new DrawFinishedEventArgs();

            Finished?.Invoke(this, gameFinishedEventArgs);
        }
    }
}
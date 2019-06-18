using System;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Lines;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Events.GameUseArgs;
using iTechArt.TicTacToe.Foundation.GameLogic;

namespace iTechArt.TicTacToe.Foundation.Progress
{
    public sealed class ProgressManager : IProgressManager
    {
        private HashSet<ILine> lines;

        private readonly IBoard _board;
        
        private readonly ILineFactory _lineFactory;


        public EventHandler<GameFinishedEventArgs> Finished { get; set; }

        public ProgressManager(IBoard board, ILineFactory lineFactory)
        {
            _board = board;
            _lineFactory = lineFactory;
        }


        private void InitLineCollection()
        {
            //horizontal lines
            var lineCollects = Enumerable.Range(1, _board.Size)
                .Select(row => _board.Where(cell => cell.Row == row));

            var linesList = lineCollects.Select(rowLine => _lineFactory.CreateLine(rowLine)).ToList();

            //vertical lines
            lineCollects = Enumerable.Range(1, _board.Size)
                .Select(column => _board.Where(cell => cell.Column == column));

            linesList.AddRange( lineCollects.Select(colLine => new Line(colLine)) );

            //diagonal lines
            linesList.Add(new Line(_board.Where(cell => cell.Row == cell.Column)));
            int rowNum = 1, colNum = _board.Size;
            linesList.Add(
                new Line(Enumerable.Range(1, _board.Size)
                                .Select(ind =>
                                    {
                                        var cell = _board[rowNum, colNum];
                                        rowNum++;
                                        colNum--;
                                        return cell;
                                    }
                                )
                        )
            );

            lines = new HashSet<ILine>(linesList);
        }


        public void CalcGameProgress()
        {
            if(lines.First(line => line.State == LineState.Winning) != null || lines.Count == 0)
            {
                EmitGameFinishedEvent();
            }
            lines.RemoveWhere(line => line.State == LineState.Standoff);
        }


        private void EmitGameFinishedEvent()
        {
            var gameFinishedEventArgs = lines.Count == 0
                ? new GameFinishedEventArgs(GameResult.Win, lines)
                : new GameFinishedEventArgs(GameResult.Draw, lines);
            Finished?.Invoke(this, gameFinishedEventArgs);
        }
    }
}

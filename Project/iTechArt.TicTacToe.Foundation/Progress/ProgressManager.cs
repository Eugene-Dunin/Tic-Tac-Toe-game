using iTechArt.TicTacToe.Foundation.Events.GameToUIArgs;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Lines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Progress
{
    public sealed class GameProgressManager : BaseProgressManager
    {
        private readonly IFigurePointsCounterFactory figurePointsCounterFactory;

        public GameProgressManager(IBoard board, IFigurePointsCounterFactory figurePointsCounterFactory)
            : base(board)
        {
            this.figurePointsCounterFactory = figurePointsCounterFactory ?? throw new NullReferenceException();
        }

        protected override void InitLineCollection()
        {
            int matrixSize = (int)Math.Sqrt(board.Cells.Count);

            var linesList = new List<ILine>();

            //horizontal lines
            var lineCollects = Enumerable.Range(1, matrixSize)
                .Select(row => board.Cells.Where(cell => cell.Row == row));
            foreach (var rowLine in lineCollects)
            {
                linesList.Add(new Line(rowLine));
            }

            //vertical lines
            lineCollects = Enumerable.Range(1, matrixSize)
                .Select(column => board.Cells.Where(cell => cell.Column == column));
            foreach (var colLine in lineCollects)
            {
                linesList.Add(new Line(colLine));
            }

            //diagonal lines
            linesList.Add(new Line(board.Cells.Where(cell => cell.Row == cell.Column)));
            int position = 0;
            linesList.Add(
                new Line(Enumerable.Range(1, matrixSize)
                                .Select(ind =>
                                    {
                                        position += matrixSize - 1;
                                        return board.Cells[position];
                                    }
                                )
                        )
            );

            lines = new HashSet<ILine>(linesList);
        }

        protected override void CalcFigurePoints()
        {
            foreach (var winLine in lines.Where(line => line.State == LineState.Winning))
            {
                var figurePointsCounter = figurePointsCounters
                                            .Where(figurePointsCounterElem => figurePointsCounterElem.Type == winLine.WinningFigure.Type)
                                            .First();
                if (figurePointsCounter != null)
                {
                    figurePointsCounter.IncrementPoints(this);
                }
                else
                {
                    figurePointsCounter = new FigurePointsCounter(winLine.WinningFigure.Type);
                    figurePointsCounters.Add(figurePointsCounter);
                }
            }
        }

        protected override void EmitGameFinishedEvent()
        {
            GameFinishedEventArgs gameFinishedEventArgs = null;
            var maxFigurePoints = figurePointsCounters.ElementAt(figurePointsCounters.Max(figurePoints => figurePoints.NumberOfPoints));
            if ( figurePointsCounters
                .Where(figurePointsCounter => figurePointsCounter.NumberOfPoints == maxFigurePoints.NumberOfPoints)
                .Count() == 1 )
            {
                gameFinishedEventArgs = new GameFinishedEventArgs(GameResult.Win, figurePointsCounters);
            }
            else
            {
                gameFinishedEventArgs = new GameFinishedEventArgs(GameResult.Draw, figurePointsCounters);
            }
            GameFinished?.Invoke(this, gameFinishedEventArgs);
        }
    }
}

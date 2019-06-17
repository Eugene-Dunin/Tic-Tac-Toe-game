using iTechArt.Tic_Tac_Toe_Game.Foundation.Interfaces;
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
    public class GameProgressManager : BaseProgressManager
    {
        private readonly IFigurePointsCounterFactory figurePointsCounterFactory;

        public GameProgressManager(IBoard board, IFigurePointsCounterFactory figurePointsCounterFactory)
            : base(board)
        {
            this.figurePointsCounterFactory = figurePointsCounterFactory ?? throw new NullReferenceException();
            InitLineCollections();
        }

        private void InitLineCollections()
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

        public override void CalcGameProgress()
        {
            lines.ToList().ForEach(line => line.CalcLineProgress());
            lines.RemoveWhere(line => line.State == LineState.Standoff);
            CalcFigurePoints();
            lines.RemoveWhere(line => line.State == LineState.Winning);
            if (lines.Count == 0)
            {
                EmitGameFinishedEvent();
            }
        }

        private void CalcFigurePoints()
        {
            foreach (var winLine in lines.Where(line => line.State == LineState.Winning))
            {
                var figurePointsCounter = figurePointsCounters
                                            .Where(figurePointsCounterElem => figurePointsCounterElem.Type == winLine.WinningFigure.Type)
                                            .First();
                if (figurePointsCounter != null)
                {
                    figurePointsCounter.IncrementPoints();
                }
                else
                {
                    figurePointsCounter = new FigurePointsProgress(winLine.WinningFigure.Type);
                    figurePointsCounters.Add(figurePointsCounter);
                }
            }
        }

        private void EmitGameFinishedEvent()
        {
            
        }
    }
}

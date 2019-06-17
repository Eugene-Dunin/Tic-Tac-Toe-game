using iTechArt.TicTacToe.Foundation.Events.GameToUIArgs;
using iTechArt.TicTacToe.Foundation.Interfaces.Internals;
using iTechArt.TicTacToe.Foundation.Lines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public abstract class BaseProgressManager
    {
        protected IBoard board;

        protected HashSet<ILine> lines;

        protected HashSet<IFigurePointsCounter> figurePointsCounters;

        public EventHandler<GameFinishedEventArgs> GameFinished { get; set; }


        protected BaseProgressManager(IBoard board)
        {
            this.board = board ?? throw new NullReferenceException();
            InitLineCollection();
        }

        protected abstract void InitLineCollection();


        public void CalcGameProgress()
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

        protected abstract void CalcFigurePoints();
        protected abstract void EmitGameFinishedEvent();
    }
}

using iTechArt.TicTacToe.Foundation.Events.GameToUIArgs;
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
        }


        public abstract void CalcGameProgress();
    }
}

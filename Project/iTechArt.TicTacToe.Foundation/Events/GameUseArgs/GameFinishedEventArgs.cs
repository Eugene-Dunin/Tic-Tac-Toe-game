using System;
using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Events.GameUseArgs
{
    public class GameFinishedEventArgs : EventArgs
    {
        public GameResult Result { get; }

        public IEnumerable<ILine> FigurePoints { get; }


        public GameFinishedEventArgs(GameResult gameResult, IEnumerable<ILine> figurePoints)
        {
            Result = gameResult;

            FigurePoints = figurePoints;
        }
    }
}
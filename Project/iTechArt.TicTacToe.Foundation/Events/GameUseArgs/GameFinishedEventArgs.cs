using System;
using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Base;

namespace iTechArt.TicTacToe.Foundation.Events.GameUseArgs
{
    public class GameFinishedEventArgs: EventArgs
    {
        public GameResult Result { get; }

        public IEnumerable<BaseLine> FigurePoints { get; }


        public GameFinishedEventArgs(GameResult gameResult, IEnumerable<BaseLine> figurePoints)
        {
            Result = gameResult;

            FigurePoints = figurePoints;
        }
    }
}
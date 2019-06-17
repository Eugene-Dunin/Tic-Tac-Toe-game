using iTechArt.Tic_Tac_Toe_Game.Foundation.Events;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iTechArt.TicTacToe.Foundation.Events.GameToUIArgs
{
    public class GameFinishedEventArgs: EventArgs
    {
        public GameResult GameResult { get; }

        public HashSet<IFigurePointsCounter> FigurePoints { get; }


        public GameFinishedEventArgs(GameResult gameResult, HashSet<IFigurePointsCounter> figurePoints)
        {
            GameResult = gameResult;

            FigurePoints = figurePoints;
        }
    }
}

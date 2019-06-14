using iTechArt.TicTacToe.Foundation.Events.GameToUIArgs;
using iTechArt.TicTacToe.Foundation.GameBoard.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iTechArt.TicTacToe.Foundation.GameLogic
{
    public interface IGameProgressManager
    {
        EventHandler<GameFinishedEventArgs> GameFinished { get; set; }

        void CalcGameProgress(IGameBoardStorage gameBoardStorage);
    }
}

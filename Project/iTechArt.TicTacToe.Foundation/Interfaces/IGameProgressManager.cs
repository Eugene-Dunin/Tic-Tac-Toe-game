using iTechArt.TicTacToe.Foundation.Events.GameToUIArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameProgressManager
    {
        EventHandler<GameFinishedEventArgs> GameFinished { get; set; }

        void CalcGameProgress(IBoard gameBoardStorage);
    }
}

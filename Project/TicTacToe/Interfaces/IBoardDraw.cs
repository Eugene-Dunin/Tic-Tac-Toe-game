using iTechArt.TicTacToe.Foundation.Events.GameToUIArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Interfaces
{
    interface IBoardDraw
    {
        void Draw(GameStepFinishedEventArgs args);
    }
}

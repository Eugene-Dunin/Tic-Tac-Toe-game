using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Game.Events;
using Tic_Tac_Toe_Game.Foundation.Events;
using Tic_Tac_Toe_Game.Foundation.Figures;

namespace Tic_Tac_Toe_Game.Foundation.GameLogic
{
    public interface IGameProgressManager: IEventSource<GameFinishedEventArgs>
    {
        void CalcGameProgress(Figure[,] cellData);
    }
}

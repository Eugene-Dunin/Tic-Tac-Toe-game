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
    class GameProgressManager: IEventSource<GameFinishedEventArgs>
    {
        public event EventHandler<GameFinishedEventArgs> EventReccipientsKeeper;

        public void CalcGameProgress(Figure[,] cellData)
        {

        }

        public void OnEventHappend(GameFinishedEventArgs e)
        {
            EventReccipientsKeeper?.Invoke(this, e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Game.Events;
using Tic_Tac_Toe_Player;

namespace Tic_Tac_Toe_Game
{
    interface IUserInteractor
    {
        event EventHandler<RepeatGameEventArgs> RepeatGame;
        void OnRepeatGame(RepeatGameEventArgs e);
        Player CreatePlayer();
        int SetPlayersCount();
        int SetGameGridSize();
    }
}

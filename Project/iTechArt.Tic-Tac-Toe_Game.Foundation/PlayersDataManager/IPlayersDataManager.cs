using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Game.Foundation.Figures;
using Tic_Tac_Toe_Player;

namespace Tic_Tac_Toe_Game.Foundation.PlayersDataManager
{
    public interface IPlayersDataManager
    {
        bool IsUniquePlayer(Player player);
        bool Add(Player key, Figure value);
        string GetPlayersList();
        void SetFirstPlayer(int ind);
        IEnumerable<KeyValuePair<Player, Figure>> GetNextPlayer(bool gameFinished);
    }
}

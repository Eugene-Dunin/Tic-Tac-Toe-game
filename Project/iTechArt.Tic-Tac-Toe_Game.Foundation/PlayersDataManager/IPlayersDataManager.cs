using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Player;
using iTechArt.TicTacToe.Foundation.Figures.Base;

namespace iTechArt.TicTacToe.Foundation.PlayersDataManager
{
    public interface IPlayersDataManager
    {
        bool IsUniquePlayer(Player player);
        bool Add(Player key, IFigure value);
        string GetPlayersList();
        void SetFirstPlayer(int ind);
        IEnumerable<KeyValuePair<Player, IFigure>> GetNextPlayer(bool gameFinished);
    }
}

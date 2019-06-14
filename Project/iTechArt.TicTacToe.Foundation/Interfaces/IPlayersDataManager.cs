using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArt.TicTacToe.Foundation.Figures.Base;
using iTechArt.TicTacToe.Foundation.Players;

namespace iTechArt.TicTacToe.Foundation.Interfaces
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

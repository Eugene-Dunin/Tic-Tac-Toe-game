using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iTechArt.TicTacToe.Foundation.Base
{
    public abstract class BasePlayersDataManager
    {
        private HashSet<Player> players;
        private IFigureManager figureManager;

        protected BasePlayersDataManager(IFigureManager figureManager)
        {

        }

        public abstract bool Add(Player key);
        public abstract void SetFirstPlayer(Player player);
        public abstract IEnumerable<Player> GetNextPlayer(bool gameFinished);
    }
}

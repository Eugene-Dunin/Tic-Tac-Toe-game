using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iTechArt.TicTacToe.Foundation.Base
{
    public abstract class BaseGameConfigManager
    {
        private readonly HashSet<Player> players;


        public IBoard Board { get; }


        public BaseProgressManager ProgressManager { get; }


        public BaseGameConfigManager(
            HashSet<Player> players, 
            int matrixSize,
            IBoardFactory boardFactory, 
            IProgressManagerFactory progressManagerFactory )
        {
            this.players = players;
            Board = boardFactory.CreateBoard(matrixSize);
            ProgressManager = progressManagerFactory.CreateProgressManager(Board);
        }

        public abstract IEnumerable<Player> GetNextPlayer(bool gameFinished);

        public BaseGameConfigManager Clone()
        {

        }

    }
}

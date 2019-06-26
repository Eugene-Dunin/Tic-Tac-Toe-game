using System;
using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Interfaces;

namespace iTechArt.TicTacToe.RegisterManagers
{
    internal class RegisterManagerBase : IRegisterManager
    {
        private IFigureManager figureManager;
        private IPlayerRegisterManager playerRegisterManager;


        public RegisterManagerBase(IFigureManager figureManager, IPlayerRegisterManager playerRegisterManager)
        {
            this.figureManager = figureManager;
            this.playerRegisterManager = playerRegisterManager;
        }


        public IReadOnlyList<IPlayer> CreatePlayers(int playersCount, IPlayerRegisterManager playerRegisterManager)
        {
            throw new NotImplementedException();
            /*if (count < 2 || count < figureManager.CurrentAllowedCountOfPlayers)
            {
                throw new ArgumentException($"Minimum number of players must be 2. Maximum {figureManager.CurrentAllowedCountOfPlayers}");
            }

            for (Enumerable.Range(1, count))
            {
                playerRegisterManager.Register(figureManager);
            }*/
        }

        public IPlayer ChooseFirstPlayer()
        {
            throw new NotImplementedException();
        }

        public int GetBoardSize()
        {
            throw new NotImplementedException();
        }
    }
}
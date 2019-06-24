using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Interfaces;

namespace iTechArt.TicTacToe.InputManagers
{
    internal abstract class BaseInputManager : IGameInputProvider
    {
        private readonly IUserNotificationManager userNotificationManager;


        protected BaseInputManager(IUserNotificationManager userNotificationManager)
        {
            this.userNotificationManager = userNotificationManager;
        }


        protected abstract void SetPlayerInfo();

        protected abstract IPlayer CreatePlayer(FigureType figure);

        protected abstract string ChooseFigureType();


        public IPlayer RegisterNewPlayer(IFigureManager figureManager)
        {
            SetPlayerInfo();
            userNotificationManager.ShowFigureTypes(figureManager);
            while (true)
            {
                var figureName = ChooseFigureType();
                if (figureManager.PopFigureType(figureName).HasValue)
                {
                    return CreatePlayer(figureManager.PopFigureType(figureName).Value);
                }
                userNotificationManager.ShowFigureTypeChooseError(figureName);
            }
        }


        public abstract IPlayer ChooseFirstPlayer(IReadOnlyCollection<IPlayer> players);

        public abstract int GetBoardSize();

        public abstract bool RepeatGame();

        public abstract bool CloseApp();

        public abstract (int row, int col) GetCellCoordinates(IPlayer player);
    }
}
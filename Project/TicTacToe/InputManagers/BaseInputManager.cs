using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Interfaces;

namespace iTechArt.TicTacToe.InputManagers
{
    internal abstract class BaseInputManager : IGameInputProvider
    {
        private readonly IUserNotificationManager _userNotificationManager;


        protected BaseInputManager(IUserNotificationManager userNotificationManager)
        {
            _userNotificationManager = userNotificationManager;
        }


        protected abstract void SetPlayerInfo();

        protected abstract IPlayer CreatePlayer(FigureType figureType);

        protected abstract string ChooseFigureType();


        public IPlayer RegisterNewPlayer(IFigureManager figureManager)
        {
            SetPlayerInfo();
            _userNotificationManager.ShowFigureTypes(figureManager);
            while (true)
            {
                var figureName = ChooseFigureType();
                if (figureManager.PopFigureType(figureName).HasValue)
                {
                    return CreatePlayer(figureManager.PopFigureType(figureName).Value);
                }
                _userNotificationManager.ShowFigureTypeChooseError(figureName);
            }
        }


        public abstract IPlayer ChooseFirstPlayer(IReadOnlyCollection<IPlayer> players);

        public abstract int GetBoardSize();

        public abstract bool RepeatGame();

        public abstract bool CloseApp();

        public abstract (int row, int col) GetCellCoordinates(IPlayer player);
    }
}
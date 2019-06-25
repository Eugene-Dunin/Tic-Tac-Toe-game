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


        public IPlayer RegisterNewPlayer(IFigureManager figureManager)
        {
            SetPlayerInfo();
            _userNotificationManager.ShowFigureTypes(figureManager);
            while (true)
            {
                var figureName = ChooseFigureType();
                var figureType = figureManager.PopFigureType(figureName);
                if (figureType.HasValue)
                {
                    return CreatePlayer(figureType.Value);
                }
                _userNotificationManager.ShowFigureTypeChooseError(figureName);
            }
        }

        public abstract IPlayer ChooseFirstPlayer(IReadOnlyCollection<IPlayer> players);

        public abstract int GetBoardSize();

        public abstract bool RepeatGame();

        public abstract bool CloseApp();

        public abstract (int row, int col) GetCellCoordinates(IPlayer player);


        protected abstract void SetPlayerInfo();

        protected abstract IPlayer CreatePlayer(FigureType figureType);

        protected abstract string ChooseFigureType();
    }
}
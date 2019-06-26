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


        public void RegisterNewPlayer(IFigureManager figureManager)
        {
            /*SetPlayerInfo();
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
            }*/
        }

        public abstract (int row, int col) GetCellCoordinates(IPlayer player);
    }
}
using iTechArt.Tic_Tac_Toe_Game.Foundation.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Game.Events;
using Tic_Tac_Toe_Game.Foundation.GameLogic;
using Tic_Tac_Toe_Player;

namespace Tic_Tac_Toe_Game.UserInteraction
{
    class UserInteractor: IUserInteractor
    {
        private static readonly string PLAYERS_COUNT_INPUT_MES = "Please input players count";
        private static readonly string REPEAT_PLAYERS_COUNT_INPUT_MES =
            "Players count incorrect. \n Please, repeat input";
        private static readonly string GRID_SIZE_INIT_MES = "Please input grid size.";
        private static readonly string REPEAT_GRID_SIZE_INIT_MES =
            "Grid size incorrect. \n Please, repeat input";
        private static readonly string ERROR_AGE_INIT_MES = "Incorrect age. Age must be a number.";
        private static readonly string REPEAT_GAME_MESSAGE = "Do you wish repeat game?";
        private static readonly string INCORRECT_INPUT_FOR_REPEAT_GAME_MESSAGE = "Incorrect command, please repeat.";
        private static readonly string REPEAT_GAME_ANSWER_TIP_MESSAGE = "Type \"Yes\" or \"No\"";
            
        private static readonly Lazy<UserInteractor> userInteractor =
            new Lazy<UserInteractor>(() => new UserInteractor());

        private UserInteractor() { }

        public static IUserInteractor GetInstance()
        {
            return userInteractor.Value;
        }

        public int SetPlayersCount(IMessageNotification messageNotification)
        {
            int result;
            messageNotification.DisplayMessage(PLAYERS_COUNT_INPUT_MES);
            do
            {
                if (int.TryParse(Console.ReadLine(), out result) && result >=2 )
                {
                    break;
                }
                messageNotification.DisplayMessage(REPEAT_PLAYERS_COUNT_INPUT_MES);
            } while (true);
            return result;
        }

        public int SetGameGridSize(IMessageNotification messageNotification)
        {
            int result;
            messageNotification.DisplayMessage(GRID_SIZE_INIT_MES);
            do
            {
                if (int.TryParse(Console.ReadLine(), out result) && result >= 3)
                {
                    break;
                }
                messageNotification.DisplayMessage(REPEAT_GRID_SIZE_INIT_MES);
            } while (true);
            return result;
        }

        public Player CreatePlayer(IMessageNotification messageNotification)
        {
            Player player = null;
            bool succseccInit;
            do
            {
                try
                {
                    player = new Player(
                        Console.ReadLine(),
                        Console.ReadLine(),
                        SetAge(messageNotification)
                    );
                    succseccInit = true;
                }
                catch (ArgumentException)
                {
                    succseccInit = false;
                }
            } while (!succseccInit);
            return player;
        }

        private int SetAge(IMessageNotification messageNotification)
        {
            int playerAge;
            while (!int.TryParse(Console.ReadLine(), out playerAge))
            {
                messageNotification.DisplayMessage(ERROR_AGE_INIT_MES);
            };
            return playerAge;
        }

        bool RepeatGame(IMessageNotification messageNotification)
        {
            messageNotification.DisplayMessage(REPEAT_GAME_MESSAGE);
            messageNotification.DisplayMessage(REPEAT_GAME_ANSWER_TIP_MESSAGE);
            do
            {
                switch (Console.ReadLine())
                {
                    case "Yes": return true;
                    case "No": return false;
                    default:
                        messageNotification.DisplayMessage(INCORRECT_INPUT_FOR_REPEAT_GAME_MESSAGE);
                        messageNotification.DisplayMessage(REPEAT_GAME_ANSWER_TIP_MESSAGE);
                        break;
                }
            } while (true);
        }

        public CellCoordinates GetCellCoordinates()
        {
            throw new NotImplementedException();
        }
    }
}

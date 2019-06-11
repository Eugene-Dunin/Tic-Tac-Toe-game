using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Game.Events;
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

        public event EventHandler<RepeatGameEventArgs> RepeatGame;

        private static readonly Lazy<UserInteractor> userInteractor =
            new Lazy<UserInteractor>(() => new UserInteractor());

        private UserInteractor() { }

        public static IUserInteractor GetInstance()
        {
            return userInteractor.Value;
        }

        public int SetPlayersCount()
        {
            int result;
            Console.WriteLine(PLAYERS_COUNT_INPUT_MES);
            do
            {
                if (int.TryParse(Console.ReadLine(), out result) && result >=2 )
                {
                    break;
                }
                Console.WriteLine(REPEAT_PLAYERS_COUNT_INPUT_MES);
            } while (true);
            return result;
        }

        public int SetGameGridSize()
        {
            int result;
            Console.WriteLine(GRID_SIZE_INIT_MES);
            do
            {
                if (int.TryParse(Console.ReadLine(), out result) && result >= 3)
                {
                    break;
                }
                Console.WriteLine(REPEAT_GRID_SIZE_INIT_MES);
            } while (true);
            return result;
        }

        public Player CreatePlayer()
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
                        SetAge()
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

        private int SetAge()
        {
            int playerAge;
            while (!int.TryParse(Console.ReadLine(), out playerAge))
            {
                Console.WriteLine(ERROR_AGE_INIT_MES);
            };
            return playerAge;
        }

        public void OnRepeatGame(RepeatGameEventArgs e)
        {
            (RepeatGame)?.Invoke(this, e);
        }
    }
}

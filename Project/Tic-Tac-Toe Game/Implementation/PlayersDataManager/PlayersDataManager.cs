using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Game.Foundation.Figures;
using Tic_Tac_Toe_Player;

namespace Tic_Tac_Toe_Game.Foundation.PlayersDataManager
{
    class PlayersDataManager : IPlayersDataManager
    {
        public const string INUNIQUE_PLAYER_NOTIFICATION_MESSAGE = "This player is exists. Try again.";
        private Dictionary<Player, Figure> playersData;

        public PlayersDataManager(int capacity)
        {
            playersData = new Dictionary<Player, Figure>(capacity);
        }

        public bool IsUniquePlayer(Player player)
        {
            return playersData.Keys.Contains(player) ? false : true;
        }

        public bool Add(Player key, Figure value)
        {
            if (IsUniquePlayer(key))
            {
                playersData.Add(key, value);
                return true;
            }
            return false;
        }

        public void SetFirstPlayer(int ind)
        {
            Player firstPlayer = playersData.Keys.ToList()[ind - 1];
            var firstPlayerData = playersData.ElementAt(ind - 1);
            playersData.Remove(firstPlayer);

            var dictionary = new Dictionary<Player, Figure>()
            {
                { firstPlayerData.Key, firstPlayerData.Value }
            };
            playersData = dictionary.Concat(playersData).ToDictionary(x => x.Key, x => x.Value);
        }

        public string GetPlayersList()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int counter = 0;
            foreach (var player in playersData.Keys)
            {
                stringBuilder.Append(String.Format("{0}) {1}" + Environment.NewLine, ++counter, player.ToString()));
            }
            return stringBuilder.ToString();
        }

        public IEnumerable<KeyValuePair<Player, Figure>> GetNextPlayer(bool gameFinished)
        {
            do
            {
                foreach (var playerData in playersData)
                {
                    if (gameFinished)
                    {
                        yield break;
                    }
                    else
                    {
                        yield return playerData;
                    }
                }

            } while (true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Player;
using Tic_Tac_Toe_Figure;

namespace Tic_Tac_Toe_Game
{
    class PlayersDataCollection
    {

        private Dictionary<Player, Figure> playersData;
        protected PlayersDataCollection(Dictionary<Player, Figure> playersData)
        {
            this.playersData = playersData ?? throw new NullReferenceException("Collection should not be null.");
        }

        public IEnumerable<KeyValuePair<Player, Figure>> NextPlayer(bool gameFinished)
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

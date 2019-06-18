using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Players;

namespace iTechArt.TicTacToe.Foundation.Configs
{
    public class GameConfig : IGameConfig
    {
        public IReadOnlyList<Player> Players { get; }
        public int BoardSize { get; }
        public IEnumerable<Player> Enumerable { get; set; }

        public GameConfig(ICollection<Player> players, Player firstPlayer, int boardSize)
        {
            var realPlayers = new HashSet<Player>(players);

            if (realPlayers.Count == players.Count())
            {
                throw new ArgumentException("The set of players contains duplicate player(s).");
            }

            if (realPlayers.Any(player => player.Figure == null))
            {
                throw new ArgumentException("Not all players have figures.");
            }

            var figureTypes = realPlayers.Select(player => player.Figure.Type);
            if ((new HashSet<FigureType>(realPlayers.Select(player => player.Figure.Type))).Count
                != figureTypes.Count())
            {
                throw new ArgumentException("Players have duplicate figure types.");
            }

            if (players.Contains(firstPlayer))
            {
                players.Remove(firstPlayer);
                var playersList = new List<Player> {firstPlayer};
                playersList.AddRange(players);

                Players = playersList;
            }
            else
            {
                throw new ArgumentException("First player not found in players set.");
            }


            if (boardSize > 3)
            {
                BoardSize = boardSize;
            }
            else
            {
                throw new ArgumentException("Board size must be 3 or more.");
            }
        }
    }
}
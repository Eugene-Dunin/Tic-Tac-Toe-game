using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Configs
{
    public class Config : IGameConfig
    {
        public IReadOnlyList<IPlayer> Players { get; }

        public IPlayer FirstPlayer { get; }

        public int BoardSize { get; }


        public Config(IReadOnlyCollection<IPlayer> players, IPlayer firstPlayer, int boardSize)
        {
            if (players.Distinct().Count() != players.Count())
            {
                throw new ArgumentException("The set of players contains duplicate player(s).");
            }

            var figureTypes = players.Select(player => player.FigureType).ToList();

            if (figureTypes.Distinct().Count() != figureTypes.Count())
            {
                throw new ArgumentException("Players have duplicate figure types.");
            }

            if (!players.Contains(firstPlayer))
            {
                throw new ArgumentException("First player not found in players set.");
            }

            if (boardSize < 3)
            {
                throw new ArgumentException("Board size must be 3 or more.");
            }

            Players = players.ToList();
            FirstPlayer = firstPlayer;
            BoardSize = boardSize;
        }
    }
}
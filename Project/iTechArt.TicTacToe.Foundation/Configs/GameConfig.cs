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
        public IReadOnlyList<IPlayer> Players { get; }

        public IPlayer FirstPlayer { get; }

        public int BoardSize { get; }


        public GameConfig(ICollection<IPlayer> players, IPlayer firstPlayer, int boardSize)
        {
            if (players.Distinct().Count() != 0)
            {
                throw new ArgumentException("The set of players contains duplicate player(s).");
            }

            if (players.Select(player => player.FigureType).Distinct().Count() != 0)
            {
                throw new ArgumentException("Players have duplicate figure types.");
            }

            if (players.Contains(firstPlayer))
            {
                FirstPlayer = firstPlayer;
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
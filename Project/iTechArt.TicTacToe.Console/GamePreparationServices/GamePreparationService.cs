using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Console.Extensions;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.GamePreparationServices
{
    public class GamePreparationService : IGamePreparationService
    {
        private readonly IConsole _console;
        private readonly IGameConfigFactory _gameConfigFactory;
        private readonly IPlayerRegisterManager _playerRegisterManager;
        private readonly IConsoleInputProvider _inputProvider;


        public GamePreparationService(
            IGameConfigFactory gameConfigFactory,
            IPlayerRegisterManager playerRegisterManager,
            IConsoleInputProvider inputProvider,
            IConsole console)
        {
            _gameConfigFactory = gameConfigFactory;
            _playerRegisterManager = playerRegisterManager;
            _inputProvider = inputProvider;
            _console = console;
        }


        public IGameConfig PrepareForGame(IGameConfig gameConfig)
        {
            var players = gameConfig?.Players.ToList() ?? CreatePlayers();
            var firstPlayer = ChooseFirstPlayer(players);
            var boardSize = GetBoardSize();

            return _gameConfigFactory.CreateGameConfig(players, firstPlayer, boardSize);
        }


        private IReadOnlyList<IPlayer> CreatePlayers()
        {
            var figureTypesSet = ((FigureType[])Enum.GetValues(typeof(FigureType))).ToList();

            int playersCount;
            do
            {
                playersCount = _inputProvider.GetNumber("Set players count",
                    "Incorrect players count, it must be a number. Try again.");
                if (playersCount > 1 && playersCount <= figureTypesSet.Count)
                {
                    break;
                }

                _console.WriteLine($"Max count of players {figureTypesSet.Count}.");
            } while (true);

            var players = new List<IPlayer>(playersCount);
            for (var playerNum = 1; playerNum <= playersCount; playerNum++)
            {
                _console.WriteLine($"{playerNum} player:");
                var player = _playerRegisterManager.Register(figureTypesSet);
                figureTypesSet.Remove(player.FigureType);
                players.Add(player);
            }

            return players;
        }

        private IPlayer ChooseFirstPlayer(IReadOnlyList<IPlayer> players)
        {
            players.ForEach((player, index) => _console.WriteLine($"{index + 1}) {player.Name} {player.LastName}"));

            do
            {
                var playerNum = _inputProvider.GetNumber("Input number of player who will go first.");
                if (playerNum >= 1 && playerNum <= players.Count)
                {
                    return players[playerNum - 1];
                }
                _console.WriteLine("There is no player with that number");
            } while (true);
        }

        private int GetBoardSize()
        {
            do
            {
                var boardSize = _inputProvider.GetNumber("Set gameBoardSize. Min size 3.",
                    "Incorrect board size, it must be a number. Try again.");
                if (boardSize > 3)
                {
                    return boardSize;
                }
                _console.WriteLine($"Board size must be 3 or more.");
            } while (true);
        }
    }
}
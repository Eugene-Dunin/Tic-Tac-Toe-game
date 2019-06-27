using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.GamePreparationServices
{
    public class GamePreparationService : IGamePreparationService
    {
        private readonly IConsole _console;
        private readonly IConsoleInputProvider _inputProvider;
        private readonly IReadOnlyList<FigureType> _figureTypesSet;

        private List<FigureType> _allowedFigureTypes;
        private IReadOnlyList<IPlayer> _players;


        public GamePreparationService(IConsoleInputProvider inputProvider, IConsole console)
        {
            _inputProvider = inputProvider;
            _console = console;
            _figureTypesSet = ((FigureType[])Enum.GetValues(typeof(FigureType))).ToList();
        }


        public IGameConfig PrepareForGame(IGameConfigFactory gameConfigFactory, IPlayerRegisterManager playerRegisterManager)
        {
            var players = CreatePlayers(playerRegisterManager);
            var firstPlayer = ChooseFirstPlayer();
            var boardSize = GetBoardSize();
            return gameConfigFactory.CreateGameConfig(players, firstPlayer, boardSize);
        }


        private IReadOnlyList<IPlayer> CreatePlayers(IPlayerRegisterManager playerRegisterManager)
        {
            int playersCount;
            do
            {
                playersCount = _inputProvider.GetNumber("Set players count",
                    "Incorrect players count, it must be a number. Try again.");
                if (playersCount <= _figureTypesSet.Count)
                {
                    break;
                }

                _console.WriteLine($"Max count of players {_figureTypesSet.Count}.");
            } while (true);


            _allowedFigureTypes = _figureTypesSet.ToList();

            var counter = 1;
            _players = Enumerable.Range(1, playersCount).Select(i =>
            {
                _console.WriteLine($"{counter} player:");
                var player = playerRegisterManager.Register(_allowedFigureTypes);
                _allowedFigureTypes.Remove(player.FigureType);
                counter++;
                return player;
            }).ToList();

            return _players;
        }

        private IPlayer ChooseFirstPlayer()
        {
            foreach (var i in Enumerable.Range(0, _players.Count))
            {
                _console.WriteLine($"{i + 1}) {_players[i].Name} {_players[i].LastName}");
            }

            int playerNum;
            do
            {
                playerNum = _inputProvider.GetNumber("Input number of player who will go first.");
                if (playerNum >= 1 && playerNum <= _players.Count)
                {
                    break;
                }
                _console.WriteLine("There is no player with that number");
            } while (playerNum >= 1 && playerNum <= _players.Count);

            return _players[playerNum - 1];
        }

        private int GetBoardSize()
        {
            return _inputProvider.GetNumber("Set gameBoardSize",
                "Incorrect board size, it must be a number. Try again.");
        }
    }
}
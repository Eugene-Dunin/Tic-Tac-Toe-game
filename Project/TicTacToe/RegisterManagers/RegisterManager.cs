using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Interfaces;

namespace iTechArt.TicTacToe.RegisterManagers
{
    internal class RegisterManager : IRegisterManager
    {
        private readonly IConsoleInputProvider _inputProvider;
        private readonly IReadOnlyList<FigureType> _figureTypesSet;

        private List<FigureType> _allowedFigureTypes;
        private IReadOnlyList<IPlayer> _players;


        public RegisterManager(IConsoleInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
            _figureTypesSet = ((FigureType[])Enum.GetValues(typeof(FigureType))).ToList();
        }


        public IReadOnlyList<IPlayer> CreatePlayers(IPlayerRegisterManager playerRegisterManager)
        {
            var playersCount = _inputProvider.GetNumber("Set players count",
                "Incorrect players count, it must be a number. Try again.");

            _allowedFigureTypes = _figureTypesSet.ToList();

            _players = Enumerable.Range(1, playersCount).Select(i =>
            {
                var player = playerRegisterManager.Register(_allowedFigureTypes);
                _allowedFigureTypes.Remove(player.FigureType);

                return player;
            }).ToList();

            return _players;
        }

        public IPlayer ChooseFirstPlayer()
        {
            foreach (var i in Enumerable.Range(0, _players.Count - 1))
            {
                _inputProvider.Console.WriteLine($"{i + 1}) {_players[i].Name} {_players[i].LastName}");
            }

            int playerNum;
            do
            {
                playerNum = _inputProvider.GetNumber("Input number of player who will go first.",
                    "Is not a number.");
                if (playerNum >= 1 && playerNum <= _players.Count)
                {
                    break;
                }
                _inputProvider.Console.WriteLine("There is no player with that number");
            } while (playerNum >= 1 && playerNum <= _players.Count);

            return _players[playerNum - 1];
        }

        public int GetBoardSize()
        {
            return _inputProvider.GetNumber("Set gameBoardSize",
                "Incorrect board size, it must be a number. Try again.");
        }
    }
}
using iTechArt.TicTacToe.Foundation.GameLogic;
using System.Collections.Generic;
using iTechArt.TicTacToe.FigureManagers;
using iTechArt.TicTacToe.Foundation.Cells;
using iTechArt.TicTacToe.Foundation.Configs;
using iTechArt.TicTacToe.Foundation.Events.GameUseArgs;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.GameBoard;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Lines;
using iTechArt.TicTacToe.InputManagers;
using iTechArt.TicTacToe.Interfaces;

namespace iTechArt.TicTacToe
{
    internal class Program
    {
        private static readonly List<IPlayer> Players;

        private static readonly IBoardDraw BoardDraw;

        private static readonly BaseInputManager InputManager;

        private static readonly IUserNotificationManager UserNotificationManager;

        private static readonly IFigureManager FigureManager;

        private static readonly IGameConfigFactory GameConfigFactory;
        private static readonly IBoardFactory BoardFactory;
        private static readonly IFigureFactory FigureFactory;
        private static readonly ICellFactory CellFactory;
        private static readonly ILinesFactory LinesFactory;

        private static IGameConfig _gameConfig;

        static Program()
        {
            GameConfigFactory = new GameConfigFactory();
            BoardFactory = new BoardFactory();
            CellFactory = new CellFactory();
            FigureFactory = new FigureFactory();
            LinesFactory = new LinesFactory();
        }


        private static void Main(string[] args)
        {
            _gameConfig = Register();
            var game = Builder(_gameConfig);
            game.Start();

            do
            {
                if (InputManager.RepeatGame())
                {
                    game = Builder(_gameConfig);
                    game.Start();
                }
                else
                {
                    _gameConfig = Register();
                    game = Builder(_gameConfig);
                    game.Start();
                }
            } while (InputManager.CloseApp());
        }

        private static Game Builder(IGameConfig config)
        {
            var game = new Game(config, BoardFactory, FigureFactory, CellFactory, LinesFactory, InputManager);
            game.GameFinishedEvent += OnGameFinished;
            game.StepFailedEvent += OnStepFailed;
            return game;
        }

        private static IGameConfig Register()
        {
            while (FigureManager.CurrentAllowedCountOfPlayers != 0)
            {
                Players.Add(InputManager.RegisterNewPlayer(FigureManager));
            }
            var firstPlayer = InputManager.ChooseFirstPlayer(Players);
            var boardSize = InputManager.GetBoardSize();
            return GameConfigFactory.CreateBaseGameConfigManager(Players, firstPlayer, boardSize);
        }

        private static void OnGameFinished(object sender, GameFinishedEventArgs args)
        {
            UserNotificationManager.ShowWinner(args);
        }

        private static void OnStepFinished(object sender, StepFinishedEventArgs args)
        {
            BoardDraw.Draw(args);
        }

        private static void OnStepFailed(object sender, StepFailedEventArgs args)
        {
            UserNotificationManager.ShowStepFailedMessage(args);
        }
    }
}
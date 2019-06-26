using iTechArt.TicTacToe.Foundation.GameLogic;
using System.Collections.Generic;
using iTechArt.TicTacToe.FigureManagers;
using iTechArt.TicTacToe.Foundation.Cells;
using iTechArt.TicTacToe.Foundation.Configs;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.GameBoard;
using iTechArt.TicTacToe.Foundation.GameLogic.Finish;
using iTechArt.TicTacToe.Foundation.GameLogic.StepDone;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Lines;
using iTechArt.TicTacToe.InputManagers;
using iTechArt.TicTacToe.Interfaces;
using iTechArt.TicTacToe.NotificationManagers;

namespace iTechArt.TicTacToe
{
    internal class Program
    {
        private static readonly IBoardDraw BoardDraw;
        private static readonly BaseInputManager InputManager;
        private static readonly IUserNotificationManager UserNotificationManager;
        private static readonly IFigureManager FigureManager;
        private static readonly IGameConfigFactory GameConfigFactory;
        private static readonly ICellFactory CellFactory;
        private static readonly IFigureFactory FigureFactory;
        private static readonly IBoardFactory BoardFactory;
        private static readonly ILinesFactory LinesFactory;
        private static readonly IRegisterManager RegisterManager;
        private static readonly IPlayerRegisterManager PlayerRegisterManager;
        private static readonly IPartyFinishedProvider PartyFinishedProvider;

        private static IGameConfig _gameConfig;


        static Program()
        {
            GameConfigFactory = new ConfigFactory();
            CellFactory = new CellFactory();
            FigureFactory = new FigureFactory();
            BoardFactory = new BoardFactory(FigureFactory, CellFactory);
            LinesFactory = new LinesFactory();

            UserNotificationManager = new NotificationManager();
            InputManager = new InputManager(UserNotificationManager);

            FigureManager = new FigureManager(new HashSet<FigureType>(new []{FigureType.Circle, FigureType.Cross}));
        }


        private static void Main(string[] args)
        {
            _gameConfig = BuildConfig();
            var game = Builder(_gameConfig);
            game.Start();

            do
            {
                if (PartyFinishedProvider.RepeatGame())
                {
                    game = Builder(_gameConfig);
                    game.Start();
                }
                else
                {
                    _gameConfig = BuildConfig();
                    game = Builder(_gameConfig);
                    game.Start();
                }
            } while (PartyFinishedProvider.CloseApp());
        }

        private static IGame Builder(IGameConfig config)
        {
            var game = new Game(config, BoardFactory, LinesFactory, InputManager);
            game.Finished += OnGameFinished;
            game.StepDone += OnStepDone;
            return game;
        }

        private static IGameConfig BuildConfig()
        {
            var players = RegisterManager.CreatePlayers(PlayerRegisterManager);
            var firstPlayer = RegisterManager.ChooseFirstPlayer();
            var boardSize = RegisterManager.GetBoardSize();
            return GameConfigFactory.CreateGameConfig(players, firstPlayer, boardSize);
        }

        private static void OnGameFinished(object sender, FinishedEventArgs args)
        {
            UserNotificationManager.ShowWinner(args);
        }

        private static void OnStepDone(object sender, StepDoneEventArgs args)
        {
            switch (args.Result)
            {
                case StepResult.Successful:
                    BoardDraw.Draw(((SuccessfulStepDoneEventArgs)args).Board);
                    break;
                case StepResult.CellIsFilled:
                case StepResult.CellNotExist:
                    UserNotificationManager.ShowStepDoneMessage(args);
                    break;
            }
        }
    }
}
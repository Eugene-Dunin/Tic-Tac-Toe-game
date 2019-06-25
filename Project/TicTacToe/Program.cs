using iTechArt.TicTacToe.Foundation.GameLogic;
using System.Collections.Generic;
using iTechArt.TicTacToe.FigureManagers;
using iTechArt.TicTacToe.Foundation.Cells;
using iTechArt.TicTacToe.Foundation.Configs;
using iTechArt.TicTacToe.Foundation.Events.Finishes;
using iTechArt.TicTacToe.Foundation.Events.Steps;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.GameBoard;
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
            var game = new Game(config, BoardFactory, LinesFactory, InputManager);
            game.Finished += OnGameFinished;
            game.StepDone += OnStepDone;
            return game;
        }

        private static IGameConfig Register()
        {
            var players = new List<IPlayer>();
            while (FigureManager.CurrentAllowedCountOfPlayers != 0)
            {
                players.Add(InputManager.RegisterNewPlayer(FigureManager));
            }
            var firstPlayer = InputManager.ChooseFirstPlayer(players);
            var boardSize = InputManager.GetBoardSize();
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
                        BoardDraw.Draw((StepFinishedEventArgs)args);
                        break;
                    case StepResult.CellIsFilled:
                    UserNotificationManager.ShowStepDoneMessage((StepForbiddenEventArgs)args);
                        break;
                    case StepResult.CellNotExist:

                        break;
            }
            
        }
    }
}
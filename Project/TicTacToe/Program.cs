using iTechArt.TicTacToe.Console.BoardDrawers;
using iTechArt.TicTacToe.Console.ConsoleInputManagers;
using iTechArt.TicTacToe.Console.Consoles;
using iTechArt.TicTacToe.Console.Extensions;
using iTechArt.TicTacToe.Console.FigureDrawers;
using iTechArt.TicTacToe.Console.GameInputProviders;
using iTechArt.TicTacToe.Console.GamePreparationServices;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Console.PartyFinishProviders;
using iTechArt.TicTacToe.Console.PlayerRegisterManagers;
using iTechArt.TicTacToe.Foundation.GameLogic;
using iTechArt.TicTacToe.Foundation.Cells;
using iTechArt.TicTacToe.Foundation.Configs;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.GameBoard;
using iTechArt.TicTacToe.Foundation.GameLogic.Finish;
using iTechArt.TicTacToe.Foundation.GameLogic.StepDone;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Lines;

namespace iTechArt.TicTacToe
{
    internal class Program
    {
        private static readonly IGameConfigFactory GameConfigFactory;
        private static readonly ICellFactory CellFactory;
        private static readonly IFigureFactory FigureFactory;
        private static readonly IBoardFactory BoardFactory;
        private static readonly ILinesFactory LinesFactory;
        private static readonly IGameFactory gameFactory;

        private static readonly IBoardDrawer BoardDrawer;
        private static readonly IFigureDrawersFactory FigureDrawerFactory;
        private static readonly IPlayerRegisterManager PlayerRegisterManager;
        private static readonly IGamePreparationService PreparationService;
        private static readonly IGameInputProvider InputManager;
        private static readonly IPartyFinishedProvider PartyFinishedProvider;
        private static readonly IConsole Console;
        private static readonly IConsoleInputProvider ConsoleInputProvider;

        private static IGameConfig _gameConfig;


        static Program()
        {
            GameConfigFactory = new ConfigFactory();
            CellFactory = new CellFactory();
            FigureFactory = new FigureFactory();
            BoardFactory = new BoardFactory(FigureFactory, CellFactory);
            LinesFactory = new LinesFactory();

            Console = new ConcreteConsole();
            ConsoleInputProvider = new ConsoleInputProvider(Console);

            PlayerRegisterManager = new PlayerRegisterManager(ConsoleInputProvider, Console);
            PreparationService = new GamePreparationService(GameConfigFactory, PlayerRegisterManager, ConsoleInputProvider, Console);
            InputManager = new GameInputProvider(ConsoleInputProvider, Console);
            PartyFinishedProvider = new PartyFinishProvider(ConsoleInputProvider);

            gameFactory = new GameFactory(BoardFactory, LinesFactory,InputManager);

            FigureDrawerFactory = new FigureDrawersFactory(Console);
            BoardDrawer = new BoardDrawer(Console, FigureDrawerFactory);
        }


        private static void Main(string[] args)
        {
            _gameConfig = BuildConfig();
            var game = CreateGame(_gameConfig);
            game.Start();
            RemoveGameSubscriptions(game);

            while (!PartyFinishedProvider.CloseApp())
            {
                _gameConfig = PartyFinishedProvider.RepeatGame() ? BuildConfig(_gameConfig) : BuildConfig();
                game = CreateGame(_gameConfig);
                game.Start();
                RemoveGameSubscriptions(game);
            }
        }

        private static IGameConfig BuildConfig(IGameConfig gameConfig = null)
        {
            return PreparationService.PrepareForGame(gameConfig);
        }

        private static IGame CreateGame(IGameConfig config)
        {
            var game = gameFactory.CreateGame(config);
            game.Finished += OnGameFinished;
            game.StepDone += OnStepDone;

            return game;
        }

        private static void RemoveGameSubscriptions(IGame game)
        {
            game.Finished -= OnGameFinished;
            game.StepDone -= OnStepDone;
        }

        private static void OnGameFinished(object sender, FinishedEventArgs args)
        {
            switch (args.Result)
            {
                case GameResult.Draw:
                    Console.WriteLine("Game result: DrawDefault");
                    break;
                case GameResult.Win:
                    var result = (WinFinishedEventArgs)args;
                    Console.WriteLine("Game result: Win");
                    Console.WriteLine("Win line have next cells:");
                    result.WinLine.Cells.ForEach
                        (cell => Console.WriteLine($"[{cell.Row}, {cell.Column}]"));
                    Console.WriteLine();
                    break;
            }
        }

        private static void OnStepDone(object sender, StepDoneEventArgs args)
        {
            switch (args.Result)
            {
                case StepResult.Successful:
                    BoardDrawer.Draw(((SuccessfulStepDoneEventArgs)args).Board);
                    break;
                case StepResult.CellNotExist:
                    Console.WriteLine("Selected cell is not exist.");
                    break;
                case StepResult.CellIsFilled:
                    var cell = ((CellIsFilledStepDoneEventArgs)args).FilledCell;
                    Console.WriteLine($"Cell on [{cell.Row}, {cell.Column}] filled by {cell.Figure.Type.ToString()}");
                    break;
            }
        }
    }
}
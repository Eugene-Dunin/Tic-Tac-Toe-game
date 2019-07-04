using iTechArt.TicTacToe.Console.BoardDrawers;
using iTechArt.TicTacToe.Console.ConsoleInputManagers;
using iTechArt.TicTacToe.Console.Consoles;
using iTechArt.TicTacToe.Console.Extensions;
using iTechArt.TicTacToe.Console.FigureDrawerProviders;
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
        private static readonly IGameFactory GameFactory;

        private static readonly IBoardDrawer BoardDrawer;
        private static readonly IGamePreparationService PreparationService;
        private static readonly IPartyFinishedProvider PartyFinishedProvider;
        private static readonly IConsole Console;


        static Program()
        {
            var configFactory = new ConfigFactory();
            var cellFactory = new CellFactory();
            var figureFactory = new FigureFactory();
            var boardFactory = new BoardFactory(figureFactory, cellFactory);
            var linesFactory = new LinesFactory();

            Console = new ConcreteConsole();
            var consoleInputProvider = new ConsoleInputProvider(Console);

            var playerRegisterManager = new PlayerRegisterManager(consoleInputProvider, Console);
            PreparationService = new GamePreparationService(configFactory, playerRegisterManager, consoleInputProvider, Console);
            var inputManager = new GameInputProvider(consoleInputProvider, Console);
            PartyFinishedProvider = new PartyFinishProvider(consoleInputProvider);

            GameFactory = new GameFactory(boardFactory, linesFactory,inputManager);

            var figureDrawerFactory = new FigureDrawerFactory(Console);
            var figureDrawerProvider = new FigureDrawerProvider(figureDrawerFactory);
            BoardDrawer = new BoardDrawer(Console, figureDrawerProvider);
        }


        private static void Main(string[] args)
        {
            var gameConfig = BuildConfig();
            LaunchParty(gameConfig);

            while (!PartyFinishedProvider.CloseApp())
            {
                gameConfig = PartyFinishedProvider.RepeatGame() ? BuildConfig(gameConfig) : BuildConfig();
                LaunchParty(gameConfig);
            }
        }

        private static void LaunchParty(IGameConfig gameConfig)
        {
            var game = CreateGame(gameConfig);
            game.Start();
            RemoveGameSubscriptions(game);
        }

        private static IGameConfig BuildConfig(IGameConfig gameConfig = null)
        {
            return PreparationService.PrepareForGame(gameConfig);
        }

        private static IGame CreateGame(IGameConfig config)
        {
            var game = GameFactory.CreateGame(config);
            game.Finished += OnGameFinished;
            game.StepDone += OnStepDone;

            return game;
        }

        private static void RemoveGameSubscriptions(IGame game)
        {
            game.Finished -= OnGameFinished;
            game.StepDone -= OnStepDone;
        }

        private static void OnGameFinished(object sender, FinishedEventArgs finishedArgs)
        {
            switch (finishedArgs.Result)
            {
                case GameResult.Draw:
                    Console.WriteLine("Game result: DrawDefault");
                    break;
                case GameResult.Win:
                    var result = (WinFinishedEventArgs)finishedArgs;
                    Console.WriteLine("Game result: Win");
                    Console.WriteLine($"Winner: {result.WinPlayer.Name} {result.WinPlayer.LastName}, Figure type: {result.WinPlayer.FigureType}");
                    result.WinLine.Cells.ForEach
                        (cell => Console.WriteLine($"[{cell.Row}, {cell.Column}]"));
                    Console.WriteLine();
                    break;
            }
        }

        private static void OnStepDone(object sender, StepDoneEventArgs StepDoneArgs)
        {
            switch (StepDoneArgs.Result)
            {
                case StepResult.Successful:
                    var castedArgsSuccessful = (SuccessfulStepDoneEventArgs) StepDoneArgs;
                    BoardDrawer.Draw(castedArgsSuccessful.Board);
                    break;
                case StepResult.CellNotExist:
                    Console.WriteLine("Selected cell is not exist.");
                    break;
                case StepResult.CellIsFilled:
                    var castedArgsCellIsFilled = (CellIsFilledStepDoneEventArgs)StepDoneArgs;
                    var cell = castedArgsCellIsFilled.FilledCell;
                    Console.WriteLine($"Cell on [{cell.Row}, {cell.Column}] filled by {cell.Figure.Type.ToString()}");
                    break;
            }
        }
    }
}
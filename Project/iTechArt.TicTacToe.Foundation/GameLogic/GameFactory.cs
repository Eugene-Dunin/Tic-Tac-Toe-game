using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.GameLogic
{
    public class GameFactory : IGameFactory
    {
        private readonly IBoardFactory _boardFactory;
        private readonly ILinesFactory _linesFactory;
        private readonly IGameInputProvider _gameInputProvider;


        public GameFactory(
            IBoardFactory boardFactory,
            ILinesFactory linesFactory,
            IGameInputProvider gameInputProvider)
        {
            _boardFactory = boardFactory;
            _linesFactory = linesFactory;
            _gameInputProvider = gameInputProvider;
        }

        
        public IGame CreateGame(IGameConfig gameConfig)
        {
            return new Game(gameConfig, _boardFactory, _linesFactory, _gameInputProvider);
        }
    }
}
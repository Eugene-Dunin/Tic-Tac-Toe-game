using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.GameBoard
{
    public class BoardFactory : IBoardFactory
    {
        private readonly IFigureFactory _figureFactory;
        private readonly ICellFactory _cellFactory;

        public BoardFactory(IFigureFactory figureFactory, ICellFactory cellFactory)
        {
            _figureFactory = figureFactory;
            _cellFactory = cellFactory;
        }

        public IBoard CreateBoard(int size)
        {
            return new Board(size, _figureFactory, _cellFactory);
        }
    }
}
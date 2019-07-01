using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTechArt.TicTacToe.Console.FigureDrawers;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.BoardDrawers
{
    public class BoardDrawer : IBoardDrawer
    {
        private const string VerticalLineComponent = "|";
        private const string HorizontalLineComponent = "-";

        private readonly IConsole _console;
        private readonly IReadOnlyList<FigureDrawerBase> _figureDrawers;


        public BoardDrawer(IConsole console, IFigureDrawersFactory figureDrawersFactory)
        {
            _console = console;
            _figureDrawers = figureDrawersFactory.CreateFigureDrawers();
        }


        public void Draw(IBoard board)
        {
            var horizontalLine = BuildHorizontalLine(board);

            _console.WriteLine(horizontalLine);
            foreach (var row in Enumerable.Range(1, board.Size))
            {
                DrawFigureLayer(board, row);
                _console.WriteLine(horizontalLine);
            }
        }


        private string BuildHorizontalLine(IBoard board)
        {
            var horizontalLine = new StringBuilder(board.Size * 2 + 1);
            for (var horizontalIndex = 0; horizontalIndex < board.Size * 2 + 1; horizontalIndex++)
            {
                horizontalLine.Append(HorizontalLineComponent);
            }
            return horizontalLine.ToString(); 
        }

        private void DrawFigureLayer(IBoard board, int row)
        {
            foreach (var cell in board.Where(cell => cell.Row == row).ToList())
            {
                _console.Write(VerticalLineComponent);
                if (cell.Figure != null)
                {
                    var searchedFigureDrawer = _figureDrawers.Single(figureDrawer => figureDrawer.FigureTypeToDraw == cell.Figure.Type);
                    searchedFigureDrawer.Draw(cell.Figure);
                }
                else
                {
                    _console.Write(" ");
                }
            }
            _console.WriteLine(VerticalLineComponent);
        }
    }
}
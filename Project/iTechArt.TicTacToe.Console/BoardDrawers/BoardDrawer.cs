using System.Linq;
using System.Text;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.BoardDrawers
{
    public class BoardDrawer : IBoardDrawer
    {
        private const string VerticalLineComponent = "|";
        private const string HorizontalLineComponent = "-";

        private readonly IConsole _console;
        private readonly IFigureDrawer _figureDrawer;


        public BoardDrawer(IConsole console, IFigureDrawer figureDrawer)
        {
            _console = console;
            _figureDrawer = figureDrawer;
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
            for (var horizontalIndex = 0; horizontalIndex <= board.Size * 2 + 1; horizontalIndex++)
            {
                horizontalLine.Append(HorizontalLineComponent);
            }
            return horizontalLine.ToString(); 
        }

        private void DrawFigureLayer(IBoard board, int row)
        {
            foreach (var cell in board.Where(cell => cell.Row == row))
            {
                _console.Write(VerticalLineComponent);
                _figureDrawer.Draw(cell.Figure);
            }
            _console.WriteLine(VerticalLineComponent);
        }
    }
}
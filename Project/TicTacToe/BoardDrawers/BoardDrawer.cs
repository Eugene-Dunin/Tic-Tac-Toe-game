using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Interfaces;

namespace iTechArt.TicTacToe.BoardDrawers
{
    internal class BoardDrawer : IBoardDraw
    {
        private const char VerticalLineComponent = '|';
        private const char HorizontalLineComponent = '-';

        private readonly IConsole _console;
        private readonly IReadOnlyList<ICharFigure> _charFigures;


        public BoardDrawer(IReadOnlyList<ICharFigure> charFigures, IConsole console)
        {
            _charFigures = charFigures;
            _console = console;
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
                _console.Write(VerticalLineComponent.ToString());
                var requiredСharFigure = _charFigures.FirstOrDefault(charFigure => charFigure.Type == cell.Figure.Type);
                if (requiredСharFigure != null) _console.Write(requiredСharFigure.FigureSymbol.ToString());
            }
            _console.WriteLine(VerticalLineComponent.ToString());
        }
    }
}
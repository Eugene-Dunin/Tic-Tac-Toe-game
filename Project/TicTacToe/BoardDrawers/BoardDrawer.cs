using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Interfaces;

namespace iTechArt.TicTacToe.BoardDrawers
{
    internal class BoardDrawer : IBoardDraw
    {
        private const char verticalLineComponent = '|';
        private const char horizontalLineComponent = '-';

        private readonly IReadOnlyList<ICharFigure> charFigures;

        public BoardDrawer(IReadOnlyList<ICharFigure> charFigures)
        {
            this.charFigures = charFigures;
        }


        public void Draw(IBoard board)
        {
            var horizontalLine = BuildHorizontalLine(board);

            Console.WriteLine(horizontalLine);
            foreach (var row in Enumerable.Range(1, board.Size))
            {
                DrawFigureLayer(board, row);
                Console.WriteLine(horizontalLine);
            }
        }

        private string BuildHorizontalLine(IBoard board)
        {
            var horizontalLine = new StringBuilder(board.Size * 2 + 1);
            for (var horizontalIndex = 0; horizontalIndex <= board.Size * 2 + 1; horizontalIndex++)
            {
                horizontalLine.Append(horizontalLineComponent);
            }
            return horizontalLine.ToString(); 
        }

        private void DrawFigureLayer(IBoard board, int row)
        {
            foreach (var cell in board.Where(cell => cell.Row == row))
            {
                Console.Write(verticalLineComponent);
                var requiredСharFigure = charFigures.FirstOrDefault(charFigure => charFigure.Type == cell.Figure.Type);
                if (requiredСharFigure != null) Console.Write(requiredСharFigure.FigureSymbol);
            }
            Console.WriteLine(verticalLineComponent);
        }
    }
}
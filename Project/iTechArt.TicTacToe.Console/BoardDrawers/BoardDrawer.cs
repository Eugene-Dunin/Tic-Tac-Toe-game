﻿using System.Collections.Generic;
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
        private readonly IFigureDrawerProvider _figureDrawerProvider;


        public BoardDrawer(IConsole console, IFigureDrawerProvider figureDrawerProvider)
        {
            _console = console;
            _figureDrawerProvider = figureDrawerProvider;
        }


        public void Draw(IBoard board)
        {
            var horizontalLine = BuildHorizontalLine(board);

            _console.WriteLine(horizontalLine);
            foreach (var row in Enumerable.Range(1, board.Size))
            {
                var cells = board.Where(cell => cell.Row == row).ToList();
                DrawFigureLayer(cells);
                _console.WriteLine(horizontalLine);
            }
        }


        private static string BuildHorizontalLine(IBoard board)
        {
            var horizontalLine = new StringBuilder(board.Size * 2 + 1);
            for (var horizontalIndex = 0; horizontalIndex < board.Size * 2 + 1; horizontalIndex++)
            {
                horizontalLine.Append(HorizontalLineComponent);
            }

            return horizontalLine.ToString(); 
        }

        private void DrawFigureLayer(IReadOnlyList<ICell> cells)
        {
            foreach (var cell in cells)
            {
                _console.Write(VerticalLineComponent);
                if (!cell.IsEmpty)
                {
                    var searchedFigureDrawer = _figureDrawerProvider.GetDrawer(cell.Figure.Type);
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
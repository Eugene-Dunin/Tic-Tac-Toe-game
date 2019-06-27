using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.FigureTypeDrawers
{
    public class FigureDrawer : IFigureDrawer
    {
        private readonly IConsole _console;


        public FigureDrawer(IConsole console)
        {
            _console = console;
        }


        public void Draw(IFigure figure)
        {
            if (figure != null)
            {
                switch (figure.Type)
                {
                    case FigureType.Circle: _console.Write("o"); break;
                    case FigureType.Cross: _console.Write("x"); break;
                }
            }
            else
            {
                _console.Write(" ");
            }
        }
    }
}
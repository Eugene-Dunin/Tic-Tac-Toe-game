using System.Collections.Generic;
using iTechArt.TicTacToe.Console.Interfaces;

namespace iTechArt.TicTacToe.Console.FigureDrawers
{
    public class FigureDrawersFactory : IFigureDrawersFactory
    {
        private readonly IConsole _console;


        public FigureDrawersFactory(IConsole console)
        {
            _console = console;
        }


        public IReadOnlyList<FigureDrawerBase> CreateFigureDrawers()
        {
            return  new List<FigureDrawerBase>()
            {
                new CircleDrawer(_console),
                new CrossDrawer(_console)
            };
        }
    }
}
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.FigureDrawers
{
    public class CrossDrawer : FigureDrawerBase
    {
        private readonly IConsole _console;


        public CrossDrawer(IConsole console)
            : base(FigureType.Cross)
        {
            _console = console;
        }


        protected override void DrawFigure(IFigure figure)
        {
            _console.Write("x");
        }
    }
}
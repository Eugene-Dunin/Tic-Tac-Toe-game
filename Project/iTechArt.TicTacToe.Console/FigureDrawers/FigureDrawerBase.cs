using System;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.FigureDrawers
{
    public abstract class FigureDrawerBase
    {
        public FigureType FigureTypeToDraw { get; }


        protected FigureDrawerBase(FigureType figureTypeToDraw)
        {
            FigureTypeToDraw = figureTypeToDraw;
        }


        public void Draw(IFigure figure)
        {
            ThrowExceptionIfFigureNoValid(figure);
            DrawFigure(figure);
        }


        protected abstract void DrawFigure(IFigure figure);


        private void ThrowExceptionIfFigureNoValid(IFigure figure)
        {
            if (figure == null)
            {
                throw new NullReferenceException("The figure is absent.");
            }

            if (figure.Type != FigureTypeToDraw)
            {
                throw new ArgumentException("The type of the drawn figure does not correspond to the type of the figure of the renderer.");
            }
        }
    }
}
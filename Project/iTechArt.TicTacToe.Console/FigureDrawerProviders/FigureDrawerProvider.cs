using System.Collections.Generic;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Console.FigureDrawerProviders
{
    public class FigureDrawerProvider : IFigureDrawerProvider
    {
        private readonly IFigureDrawerFactory _figureDrawerFactory;
        private readonly Dictionary<FigureType, IFigureDrawer> figureDrawersCache;


        public FigureDrawerProvider(IFigureDrawerFactory figureDrawerFactory)
        {
            _figureDrawerFactory = figureDrawerFactory;
            figureDrawersCache = new Dictionary<FigureType, IFigureDrawer>();
        }


        public IFigureDrawer GetDrawer(FigureType figureType)
        {
            if (figureDrawersCache.TryGetValue(figureType, out var drawer))
            {
                return drawer;
            }

            drawer = _figureDrawerFactory.CreateFigureDrawer(figureType);
            figureDrawersCache.Add(figureType, drawer);

            return drawer;
        }
    }
}
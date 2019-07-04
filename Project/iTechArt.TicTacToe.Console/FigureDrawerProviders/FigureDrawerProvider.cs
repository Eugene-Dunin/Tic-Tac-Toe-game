using System.Collections.Generic;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Console.FigureDrawerProviders
{
    public class FigureDrawerProvider : IFigureDrawerProvider
    {
        private readonly IFigureDrawerFactory _figureDrawerFactory;
        private readonly IDictionary<FigureType, IFigureDrawer> _figureDrawersCache;


        public FigureDrawerProvider(IFigureDrawerFactory figureDrawerFactory)
        {
            _figureDrawerFactory = figureDrawerFactory;
            _figureDrawersCache = new Dictionary<FigureType, IFigureDrawer>();
        }


        public IFigureDrawer GetDrawer(FigureType figureType)
        {
            if (_figureDrawersCache.TryGetValue(figureType, out var drawer))
            {
                return drawer;
            }

            drawer = _figureDrawerFactory.CreateFigureDrawer(figureType);
            _figureDrawersCache.Add(figureType, drawer);

            return drawer;
        }
    }
}
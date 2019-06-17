using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Foundation.Base
{
    public abstract class BaseFigureManager
    {
        private HashSet<IFigure> Figures { get; }


        public IEnumerable<FigureType> AllFigureTypes => Figures.Select(figure => figure.Type);


        public IFigure GetFigure(FigureType figureType)
        {
            var requiredFigure = Figures.Where(figure => figure.Type == figureType).First();
            Figures.Remove(requiredFigure);
            return requiredFigure;
        }
    }
}

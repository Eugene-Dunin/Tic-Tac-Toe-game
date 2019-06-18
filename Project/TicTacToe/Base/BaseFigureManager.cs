using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.TicTacToe.Base
{
    public abstract class BaseFigureManager
    {
        private HashSet<IFigure> figures;


        public IEnumerable<FigureType> AllFigureTypes => figures.Select(figure => figure.Type);


        public int CurrentAllowedCountOfPlayers => figures.Count;


        public IFigure GetFigure(FigureType figureType)
        {
            var requiredFigure = figures.Where(figure => figure.Type == figureType).First();
            figures.Remove(requiredFigure);
            return requiredFigure;
        }
    }
}

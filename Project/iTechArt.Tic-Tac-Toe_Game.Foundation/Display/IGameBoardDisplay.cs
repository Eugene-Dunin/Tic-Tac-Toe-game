using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_Game.Foundation.Figures;

namespace Tic_Tac_Toe_Game.Foundation.Display
{
    public interface IGameBoardDisplay
    {
        void DrawGameBoard(Figure[,] cellData);
    }
}

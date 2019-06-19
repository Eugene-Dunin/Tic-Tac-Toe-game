﻿using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Base;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface ILineFactory
    {
        BaseLine CreateLine(IEnumerable<ICell> cells);
    }
}

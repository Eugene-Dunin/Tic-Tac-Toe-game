using iTechArt.TicTacToe.Foundation.Interfaces;
﻿using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Lines
{
    public class SideDiagonal : LineBase
    {
        public SideDiagonal(IBoard board)
            : base(board, cell => cell.Row == (board.Size - cell.Column + 1))
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Interfaces.Internals;

namespace iTechArt.TicTacToe.Foundation.GameBoard
{
    public class BoardFactory : IBoardFactory
    {
        public IBoard CreateBoard(int size, IFigureFactory figureFactory, ICellFactory cellFactory)
        {
            return new Board(size, figureFactory, cellFactory);
        }
    }
}

using System.Configuration;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Interfaces
{
    internal interface IPlayerRegisterManager
    {
        IPlayer Register();
    }
}
using iTechArt.TicTacToe.Foundation.GameLogic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IProgressManagerFactory
    {
        IProgressManager CreateProgressManager(IBoard boardFactory);
    }
}

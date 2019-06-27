using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Interfaces
{
    internal interface  IGamePreparationService
    {
        IGameConfig PrepareForGame(IGameConfigFactory gameConfigFactory, IPlayerRegisterManager playerRegisterManager);
    }
}
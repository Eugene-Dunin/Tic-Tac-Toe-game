﻿using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.Interfaces
{
    public interface  IGamePreparationService
    {
        IGameConfig PrepareForGame(IGameConfigFactory gameConfigFactory, IPlayerRegisterManager playerRegisterManager);
    }
}
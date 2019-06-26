using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Interfaces;

namespace iTechArt.TicTacToe.PartyFinishProviders
{
    internal class PartyFinishProvider : IPartyFinishedProvider
    {
        private readonly IConsoleInputProvider _inputProvider;

        public PartyFinishProvider(IConsoleInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public bool RepeatGame()
        {
            return _inputProvider.YesNoQuestion("Do you wish repeat game?",
                "Incorrect answer. Please, print \"yes\" or \"no\".");
        }

        public bool CloseApp()
        {
            return _inputProvider.YesNoQuestion("Do you wish finish app?",
                "Incorrect answer. Please, print \"yes\" or \"no\".");
        }
    }
}
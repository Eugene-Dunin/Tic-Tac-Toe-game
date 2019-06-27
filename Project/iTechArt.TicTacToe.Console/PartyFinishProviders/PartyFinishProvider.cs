using iTechArt.TicTacToe.Console.Interfaces;

namespace iTechArt.TicTacToe.Console.PartyFinishProviders
{
    public class PartyFinishProvider : IPartyFinishedProvider
    {
        private readonly IConsoleInputProvider _inputProvider;


        public PartyFinishProvider(IConsoleInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }


        public bool RepeatGame()
        {
            return _inputProvider.Prompt("Do you wish repeat game?",
                "Incorrect answer. Please, print \"yes\" or \"no\".");
        }

        public bool CloseApp()
        {
            return _inputProvider.Prompt("Do you wish finish app?",
                "Incorrect answer. Please, print \"yes\" or \"no\".");
        }
    }
}
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Events.Steps
{
    public class StepFinishedEventArgs : StepDoneEventArgs
    {
        public override StepResult Result => StepResult.Successful;

        public IBoard Board { get; }


        public StepFinishedEventArgs(IBoard board)
        {
            Board = board;
        }
    }
}
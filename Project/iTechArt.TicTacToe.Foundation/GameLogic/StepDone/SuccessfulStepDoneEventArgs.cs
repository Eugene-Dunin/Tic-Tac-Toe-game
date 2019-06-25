using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.GameLogic.StepDone
{
    public class SuccessfulStepDoneEventArgs : StepDoneEventArgs
    {
        public IBoard Board { get; }


        public SuccessfulStepDoneEventArgs(IBoard board) : base(StepResult.Successful)
        {
            Board = board;
        }
    }
}
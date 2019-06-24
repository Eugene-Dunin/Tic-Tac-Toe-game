using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Events.Steps
{
    public class StepForbiddenEventArgs : StepDoneEventArgs
    {
        public override StepResult Result => StepResult.CellIsFilled;

        public ICell FilledCell { get; }


        public StepForbiddenEventArgs(ICell filledCell)
        {
            FilledCell = filledCell;
        }
    }
}
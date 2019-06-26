using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.GameLogic.StepDone
{
    public class CellIsFilledStepDoneEventArgs : StepDoneEventArgs
    {
        public ICell FilledCell { get; }


        public CellIsFilledStepDoneEventArgs(ICell filledCell) 
            : base(StepResult.CellIsFilled)
        {
            FilledCell = filledCell;
        }
    }
}
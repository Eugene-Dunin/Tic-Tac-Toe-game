namespace iTechArt.TicTacToe.Foundation.GameLogic.StepDone
{
    public class CellNotExistStepDoneEventArgs : StepDoneEventArgs
    {
        public CellNotExistStepDoneEventArgs()
            : base(StepResult.CellNotExist)
        {

        }
    }
}
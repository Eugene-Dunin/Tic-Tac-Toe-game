namespace iTechArt.TicTacToe.Foundation.Events.Steps
{
    public class StepImpossibleEventArgs : StepDoneEventArgs
    {
        public override StepResult Result => StepResult.CellNotExist;
    }
}
using iTechArt.TicTacToe.Foundation.Events.GameUseArgs;

namespace iTechArt.TicTacToe.Interfaces
{
    internal interface IBoardDraw
    {
        void Draw(StepFinishedEventArgs args);
    }
}
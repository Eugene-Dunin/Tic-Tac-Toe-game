using iTechArt.TicTacToe.Foundation.Events.GameUseArgs;
using iTechArt.TicTacToe.Foundation.Events.Steps;

namespace iTechArt.TicTacToe.Interfaces
{
    internal interface IBoardDraw
    {
        void Draw(StepFinishedEventArgs args);
    }
}
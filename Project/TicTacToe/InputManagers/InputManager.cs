using System;
using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Players;
using iTechArt.TicTacToe.Interfaces;

namespace iTechArt.TicTacToe.InputManagers
{
    internal class InputManager : BaseInputManager
    {
        private int age;
        private string name;
        private string lastname;


        public InputManager(IUserNotificationManager userNotificationManager) : base(userNotificationManager)
        {
        }


        public override IPlayer ChooseFirstPlayer(IReadOnlyCollection<IPlayer> players)
        {
            throw new System.NotImplementedException();
        }

        public override int GetBoardSize()
        {
            Console.WriteLine("Set gameBoardSize");
            do
            {
                if (int.TryParse(Console.ReadLine(), out var boardSize))
                {
                    return boardSize;
                }
                Console.WriteLine("Incorrect board size, it must be a number. Try again.");
            } while (true);
        }

        public override bool RepeatGame()
        {
            Console.WriteLine("Do you wish repeat game?");
            return YesNoQuestion();
        }

        public override bool CloseApp()
        {
            Console.WriteLine("Do you wish finish app?");
            return YesNoQuestion();
        }

        public override (int row, int col) GetCellCoordinates(IPlayer player)
        {
            do
            {
                (int row, int col) coordinates;
                if(NumberInputResultWithMessage("Input row number:" , out coordinates.row) &&
                   NumberInputResultWithMessage("Input column number:", out coordinates.col))
                {
                    return coordinates;
                }
                Console.WriteLine("Incorrect coordinates, it must be numbers. Try again.");
            } while (true);
        }


        protected override void SetPlayerInfo()
        {
            do
            {
                if (!int.TryParse(Console.ReadLine(), out age))
                {
                    Console.WriteLine("Incorrect age, it must be a number. Try again.");
                    continue;
                }
                name = Console.ReadLine();
                lastname = Console.ReadLine();
                return;
            } while (true);
        }

        protected override IPlayer CreatePlayer(FigureType figureType)
        {
            return new Player(name, lastname, age, figureType);
        }

        protected override string ChooseFigureType()
        {
            return Console.ReadLine();
        }


        private bool YesNoQuestion()
        {
            do
            {
                var answer = Console.ReadLine()?.ToUpper();
                switch (answer)
                {
                    case "YES":
                        return true;
                    case "NO":
                        return false;
                    default:
                        Console.WriteLine("Incorrect answer. Please, print \"yes\" or \"no\".");
                        break;
                }
            } while (true);
        }

        private bool NumberInputResultWithMessage(string outputBeforeMessage, out int value)
        {
            Console.WriteLine(outputBeforeMessage);
            return int.TryParse(Console.ReadLine(), out value);
        }
    }
}
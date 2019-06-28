using System;
using System.Collections.Generic;

namespace iTechArt.TicTacToe.Console.Extensions
{
    public static class IReadOnlyListExtension
    {
        public static void ForEach<T>(this IReadOnlyList<T> readOnlyList, Action<T, int> actionWithElement, int indexStartValue = 1)
        {
            var index = indexStartValue;
            foreach (var element in readOnlyList)
            {
                actionWithElement(element, index);
                index++;
            }
        }
    }
}
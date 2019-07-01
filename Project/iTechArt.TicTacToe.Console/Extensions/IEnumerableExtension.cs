using System;
using System.Collections.Generic;

namespace iTechArt.TicTacToe.Console.Extensions
{
    public static class IEnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> readOnlyList, Action<T, int> actionWithElement)
        {
            var index = 0;
            foreach (var element in readOnlyList)
            {
                actionWithElement(element, index);
                index++;
            }
        }

        public static void ForEach<T>(this IEnumerable<T> readOnlyList, Action<T> actionWithElement)
        {
            foreach (var element in readOnlyList)
            {
                actionWithElement(element);
            }
        }
    }
}
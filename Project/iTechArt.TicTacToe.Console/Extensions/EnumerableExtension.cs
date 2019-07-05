using System;
using System.Collections.Generic;

namespace iTechArt.TicTacToe.Console.Extensions
{
    public static class EnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> actionWithElement)
        {
            var index = 0;
            foreach (var element in enumerable)
            {
                actionWithElement(element, index);
                index++;
            }
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> actionWithElement)
        {
            foreach (var element in enumerable)
            {
                actionWithElement(element);
            }
        }
    }
}
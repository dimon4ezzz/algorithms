using System.Collections.Generic;

namespace Extensions
{
    /// <summary>
    /// Расширяет методы класса IList.
    /// </summary>
    public static class ListExtension
    {
        /// <summary>
        /// Перемещает элементы списка между собой.
        /// </summary>
        /// <param name="indexA">первый элемент</param>
        /// <param name="indexB">второй элемент</param>
        public static IList<T> Swap<T>(this IList<T> list, uint indexA, uint indexB)
        {
            T tmp = list[(int) indexA];
            list[(int) indexA] = list[(int) indexB];
            list[(int) indexB] = tmp;
            return list;
        }
    }
}

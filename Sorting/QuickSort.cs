using System;
using System.Collections.Generic;
using Extensions;
using Recursio;

namespace Sorting
{
    /// <summary>
    /// Реализация быстрой сортировки.
    /// </summary>
    public class QuickSort : ISort, IRecurced
    {
        /// <summary>
        /// Количество вызовов функции сортировки всего или части массива.
        /// </summary>
        public ulong CallsAmount { get; private set; }

        public QuickSort() => ResetCounter();

        /// <summary>
        /// Сбрасывает счётчик вызовов функции.
        /// </summary>
        public void ResetCounter() => CallsAmount = 0;

        /// <summary>
        /// Функция сортировки массива.
        /// </summary>
        /// <param name="sortingList">массив на сортировку</param>
        /// <typeparam name="T">тип элементов массива;
        ///  в большинстве случаев определяется автоматически</typeparam>
        public void Sort<T>(List<T> sortingList) where T : IComparable
        {
            // если массива нет в принципе,
            // очевидно, ничего не проверять и кинуть ошибку
            if (sortingList == null) throw new ArgumentNullException("list cannot be null");

            Sort(sortingList, 0, (uint)(sortingList.Count - 1));
        }

        /// <summary>
        /// Функция сортировки части массива.
        /// </summary>
        /// <param name="sortingList">массив на сортировку</param>
        /// <param name="start">начало части сортировки</param>
        /// <param name="end">конец части сортировки</param>
        /// <typeparam name="T">тип элементов массива;
        ///  в большинстве случаев определяется автоматически</typeparam>
        public void Sort<T>(List<T> sortingList, uint start, uint end) where T : IComparable
        {
            // инкремент счётчика вызовов функции
            CallsAmount++;

            // если массива нет в принципе,
            // очевидно, ничего не проверять и кинуть ошибку
            if (sortingList == null) throw new ArgumentNullException("list cannot be null");

            // если элемент на `start` находится правее элемента на `end`,
            // это очевидная ошибка
            if (start > end) throw new ArgumentException($"start cannot be on right side of the end: {start} > {end}!");

            // если начало и конец — одно и тоже,
            // очевидно, часть состоит из одного элемента
            if (start == end) return;

            // если массив состоит из одного элемента или пуст,
            // очевидно, нечего сортировать
            if (sortingList.Count < 2) return;

            // если `start` или `end` указывают на несуществующее место в массиве,
            // очевидно, это ошибка Out of Range!
            if (start >= sortingList.Count) throw new ArgumentOutOfRangeException($"start cannot be more than list length: {start} >= {sortingList.Count}!");
            if (end >= sortingList.Count) throw new ArgumentOutOfRangeException($"end cannot be more than list length: {end} >= {sortingList.Count}!");

            // находим элемент «по центру»
            var marker = GetMarker(sortingList, start, end);

            // если найденный маркер — начало подмассива, эту часть не нужно сортировать
            if (marker != start)
            {
                // сортируем части массива слева от маркера
                Sort(sortingList, 0, marker - 1);
            }

            // если найденный маркер — конец подмассива, эту часть не нужно сортировать
            if (marker != end)
            {
                // сортируем части массива справа от маркера
                Sort(sortingList, marker + 1, end);
            }   
        }

        /// <summary>
        /// Определяет маркер — элемент,
        /// для которого некоторые элементы меньше,
        /// а некоторые больше.
        /// </summary>
        /// <param name="sortingList">сортируемый массив</param>
        /// <param name="start">начало поиска</param>
        /// <param name="end">конец поиска</param>
        /// <typeparam name="T">тип элементов массива;
        ///  в большинстве случаев определяется автоматически</typeparam>
        /// <returns>маркер — некоторые элементы меньше, некоторые больше</returns>
        private uint GetMarker<T>(List<T> sortingList, uint start, uint end) where T : IComparable
        {
            // маркер определяет место между малыми числами и большими
            uint swapAmount = start;

            for (uint i = start; i < end; i++)
            {
                // если находится такой элемент, меньше конечного элемента
                if (IsLess(sortingList, i, end))
                {
                    // перенести его на место маркера
                    sortingList.Swap(i, swapAmount);

                    // перенести маркер далее
                    swapAmount++;
                }
            }

            // поменять местами маркерный элемент и конечный
            sortingList.Swap(swapAmount, end);
            return swapAmount;
        }

        private bool IsLess<T>(List<T> list, uint comparedIndex, uint comparingIndex) where T : IComparable =>
            list[(int)comparedIndex].CompareTo(list[(int)comparingIndex]) == -1;
    }
}

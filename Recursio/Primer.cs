using System;
using System.Collections.Generic;

namespace Recursio
{
    /// <summary>
    /// Класс для получения простых множителей числа.
    /// </summary>
    public class Primer : IRecurced
    {
        /// <summary>
        /// Количество вызовов функции получения простых множителей.
        /// </summary>
        public ulong CallsAmount { get; private set; }

        public Primer() => ResetCounter();

        /// <summary>
        /// Сбрасывает счётчик вызовов функции.
        /// </summary>
        public void ResetCounter() => CallsAmount = 0;

        /// <summary>
        /// Рекурсивно получает все простые множители числа.
        /// </summary>
        /// <param name="number">число для разложения</param>
        /// <returns>множество простых множителей</returns>
        /// <exception cref="ArgumentException">кидается, если число — 0
        public List<ulong> GetPrimes(ulong number)
        {
            // увеличиваем количество вызовов этой функции
            CallsAmount++;

            // если число — 0, никаких простых множителей у него нет
            if (number == 0) throw new ArgumentException("0 has no prime dividers", "number");

            // если число — 1, никаких простых множителей у него нет
            if (number == 1) return new List<ulong>();

            // создаём пустой список
            var list = new List<ulong>();

            // начинаем смотреть делители с 2
            uint multiplier = 2;

            // пока число не поделится на ближайшее простое,
            // смотрит все остальные числа
            while (number % multiplier != 0) multiplier++;

            // добавляет найденное простое число
            list.Add(multiplier);

            // добавляет найденные простые числа для оставшейся части
            list.AddRange(GetPrimes(number / multiplier));

            // полученное множество и есть множество простых множителей
            return list;
        }
    }
}

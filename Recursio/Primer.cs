using System;
using System.Collections.Generic;

namespace Recursio
{
    /// <summary>
    /// Класс для получения простых множителей числа.
    /// </summary>
    public class Primer
    {
        /// <summary>
        /// Количество вызовов функции получения простых множителей.
        /// </summary>
        /// <value></value>
        public uint CallsAmount { get; private set; }

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
        public List<uint> GetPrimes(uint number)
        {
            // увеличиваем количество вызовов этой функции
            CallsAmount++;

            // если число — 0, никаких простых множителей у него нет
            if (number == 0) throw new ArgumentException("0 has no prime dividers", "number");

            // если число — 1, это и есть простой множитель
            if (number == 1) return new List<uint> { 1 };

            // находим максимальный множитель,
            // т.н. «центр», который может быть у числа,
            // например, 120 не может иметь множителей больше 10 (121 = 11×11)
            uint center = (uint) Math.Floor(Math.Sqrt(number));
            
            // создаём пустой список
            var list = new List<uint>();

            // проходим по всем числам от 2 до центра
            for (uint i = 2; i <= center; i++)
            {
                // если это число множитель
                if (number % i == 0)
                {
                    // все его простые множители являются
                    // множителями искомого числа
                    list.AddRange(GetPrimes(i));
                }
            }

            // если никаких чисел не добавилось
            // значит проверяемое число — простое
            if (list.Count == 0) list.Add(number);

            // полученное множество и есть множество простых множителей
            return list;
        }
    }
}

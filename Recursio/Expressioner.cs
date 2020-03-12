using System;

namespace Recursio
{
    /// <summary>
    /// Рекурсивный расчёт строк-выражений.
    /// </summary>
    public class Expressioner : IRecurced
    {
        /// <summary>
        /// Количество вызовов функции получения простых множителей.
        /// </summary>
        public ulong CallsAmount { get; private set; }

        public Expressioner() => ResetCounter();

        /// <summary>
        /// Сбрасывает счётчик вызовов функции.
        /// </summary>
        public void ResetCounter() => CallsAmount = 0;

        /// <summary>
        /// Массив значений операторов первого порядка.
        /// </summary>
        private static readonly char[] plusMinus = { '+', '-', '\u2212' };

        /// <summary>
        /// Массив значений операторов второго порядка.
        /// </summary>
        private static readonly char[] multiplier = { '*', '\u00d7', '/', '\\', '\u00f7', '\u22c5' };

        /// <summary>
        /// Функция рассчёта математического выражения в строке с подстановкой указанного значения в качестве X.
        /// </summary>
        /// <param name="equation">математическое выражение</param>
        /// <param name="value">подстановочное значение</param>
        /// <returns>результат рассчёта выражения</returns>
        /// <exception cref="ArgumentNullException">кидается, если строка пуста</exception>
        /// <exception cref="FormatException">кидается, если не удалось найти в строке хотя бы число</exception>
        /// <exception cref="DivideByZeroException">кидается, если получилось деление на ноль</exception>
        public decimal Calculate(string equation, decimal value)
        {
            // увеличиваем количество вызовов
            CallsAmount++;

            // если строка пуста, кидаем исключение
            if (string.IsNullOrWhiteSpace(equation)) throw new ArgumentNullException("equation is empty", "equation");

            // находим плюс или минус в конце строки (операторы левоассоциативны)
            var delimiterPosition = equation.LastIndexOfAny(plusMinus);

            // если не найдено или плюс/минус в начале строки,
            // искать умножение или деление
            if (delimiterPosition < 1)
                delimiterPosition = equation.LastIndexOfAny(multiplier);

            // если не найдены, то попытаться найти другое
            if (delimiterPosition == -1)
            {
                switch (equation)
                {
                    // строка представляет собой выражение x
                    case "x":
                        return value;
                    // строка представляет собой число
                    default:
                        return Decimal.Parse(equation);
                }
            }

            // находим символ операции
            var operation = equation[delimiterPosition];
            // разделяем выражение на левое и правое
            var leftEquation = equation.Substring(0, delimiterPosition);
            var rightEquation = equation.Substring(delimiterPosition + 1);

            // ищем разные операции
            switch (operation)
            {
                // складываем расчётное выражение левой части выражения и правой
                case '+':
                    return Calculate(leftEquation, value) + Calculate(rightEquation, value);
                // вычитаем расчётные выражения из правой левую
                case '-': case '\u2212':
                    return Calculate(leftEquation, value) - Calculate(rightEquation, value);
                // умножаем левое расчётное выражение на правое
                case '*': case '\u00d7':
                    return Calculate(leftEquation, value) * Calculate(rightEquation, value);
                // делим левое расчётное выражение на правое
                case '/': case '\\': case '\u00f7': case '\u22c5':
                    return Calculate(leftEquation, value) / Calculate(rightEquation, value);
                // если операция каким-то образом не обнаружена,
                // выкидывается исключение парсинга
                // невозможно достичь не редактируя код
                default:
                    throw new ApplicationException($"cannot parse {equation}");
            }
        }
    }
}
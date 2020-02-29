using System;

namespace Recursio
{
    /// <summary>
    /// Класс для расчёта определителя рекурсивным способом.
    /// </summary>
    public class Determinant
    {
        /// <summary>
        /// Количество вызовов функции расчёта определителя.
        /// </summary>
        public uint CallsAmount { get; private set; }

        /// <summary>
        /// Типовой определитель.
        /// </summary>
        public Determinant() => ResetDeterminant();

        /// <summary>
        /// Сбрасывает счётчик вызовов функции.
        /// </summary>
        public void ResetDeterminant() => CallsAmount = 0;

        /// <summary>
        /// Рекурсивно считает определитель матрицы.
        /// </summary>
        /// <param name="matrix">двумерная квадратная матрица</param>
        /// <returns>определитель матрицы</returns>
        /// <exception cref="ArgumentException">кидается, если матрица пуста или не квадратна</exception>
        public double GetDeterminant(double[,] matrix)
        {
            // 
            CallsAmount++;

            // если матрица пуста, кидает исключение
            if (matrix.Length == 0) throw new ArgumentException("matrix cannot be empty");

            // если в матрице лишь один элемент, передаёт лишь его
            if (matrix.Length == 1) return matrix[0, 0];

            // если матрица неквадратная — кидает исключение
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new ArgumentException("matrix cannot be non-square");

            // сохраняем размер матрицы
            var length = matrix.GetLength(0);

            // создаём пустую матрицу для минора
            var matrixTemp = new double[length - 1, length - 1];

            // общая сумма — есть определитель
            double determinant = 0;

            // идём по первой строке
            for (uint a = 0; a < length; a++)
            {
                // идём по каждой строке, кроме первой
                for (uint i = 1, rowIterator = 0; i < length; i++, rowIterator++)
                {
                    // идём по каждому столбцу
                    for (uint j = 0, columnIterator = 0; j < length; j++)
                    {
                        // избегаем столбца выбранного элемента
                        if (j != a)
                        {
                            // добавляем в матрицу минора этот элемент
                            matrixTemp[rowIterator, columnIterator] = matrix[j, i];
                            // идём на следующий столбец
                            columnIterator++;
                        }
                    }
                }

                // находим произведение выделенного числа на алгебраическое дополнение
                determinant += (a % 2 == 0 ? 1 : -1) * matrix[a, 0] * GetDeterminant(matrixTemp);
            }
            
            // полученная сумма и есть определитель
            return determinant;
        }
    }
}

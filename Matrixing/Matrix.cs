using System;

namespace Matrixing
{
    /// <summary>
    /// Представляет собой матрицу. Использует только `double`.
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Значения в ячейках матрицы.
        /// </summary>
        protected double[,] values;

        /// <summary>
        /// Быстрое получение значения в ячейке через [,]
        /// </summary>
        /// <value>значение в ячейке</value>
        public double this[int row, int column]
        {
            get => values[row, column];
            set { values[row, column] = value; }
        }

        /// <summary>
        /// Количество строк.
        /// </summary>
        public int RowsCount { get => values.GetLength(0); }

        /// <summary>
        /// Количество колонок.
        /// </summary>
        public int ColumnsCount { get => values.GetLength(1); }

        /// <summary>
        /// Создаёт пустую матрицу с заданными размерами.
        /// </summary>
        /// <param name="rows">строк</param>
        /// <param name="columns">колонок</param>
        /// <exception name="ArgumentException">кидается, если один из размеров меньше единицы</exception>
        public Matrix(int rows, int columns)
        {
            if (rows < 1 || columns < 1)
                throw new ArgumentException("matrix cannot have 0 dimension");
            
            values = new double[rows, columns];
        }

        /// <summary>
        /// Быстрое создание матрицы.
        /// </summary>
        /// <param name="matrix">матрица в виде двумерного массива</param>
        /// <exception name="ArgumentException">кидается, если матрица пуста</exception>
        public Matrix(double[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                throw new ArgumentException("matrix cannot be empty");
                
            values = matrix;
        }

        /// <summary>
        /// Сложение матриц.
        /// </summary>
        /// <param name="left">левая матрица</param>
        /// <param name="right">правая матрица</param>
        /// <returns>матрица с элементами-суммами</returns>
        public static Matrix operator +(Matrix left, Matrix right)
        {
            if (left.AreSame(right))
                throw new ArgumentException("matrixes have not same lengthes");

            var tmpMatrix = new Matrix(left.RowsCount, left.ColumnsCount);

            for (var i = 0; i < left.RowsCount; i++)
                for (var j = 0; j < left.ColumnsCount; j++)
                    tmpMatrix[i,j] = left[i,j] + right[i,j];
            
            return tmpMatrix;
        }

        /// <summary>
        /// Разность матриц.
        /// </summary>
        /// <param name="left">левая матрица</param>
        /// <param name="right">правая матрица</param>
        /// <returns>матрица с элементами-разностями</returns>
        public static Matrix operator -(Matrix left, Matrix right)
        {
            if (left.AreSame(right))
                throw new ArgumentException("matrixes have not same lengthes");

            var tmpMatrix = new Matrix(left.RowsCount, left.ColumnsCount);

            for (var i = 0; i < left.RowsCount; i++)
                for (var j = 0; j < left.ColumnsCount; j++)
                    tmpMatrix[i,j] = left[i,j] - right[i,j];
            
            return tmpMatrix;
        }

        /// <summary>
        /// Сравнивает эту матрицу с другой и говорит, равны ли они.
        /// </summary>
        /// <param name="other">другая матрица</param>
        /// <returns>равны ли матрицы</returns>
        public bool AreSame(Matrix other) =>
            RowsCount == other.RowsCount &&
            ColumnsCount == other.ColumnsCount;

        /// <summary>
        /// Делает матрицу квадратной с чётными сторонами.
        /// </summary>
        /// <remarks>создаёт новый массив</remarks>
        public void MakeSquareAndEven()
        {
            if (RowsCount == ColumnsCount) return;
            
            var length = GetEvenLength();
            
            var tmpMatrix = new double[length, length]; 

            // do not use
            // Array.ConstrainedCopy(values, 0, tmpMatrix, 0, length);
            // it copies as One-Dimensional array

            for (var i = 0; i < RowsCount; i++)
                for (var j = 0; j < ColumnsCount; j++)
                    tmpMatrix[i,j] = values[i,j];

            values = tmpMatrix;
        }

        /// <summary>
        /// Даёт четверть матрицы.
        /// _________
        /// | 1 | 2 |
        /// |-------|
        /// | 3 | 4 |
        /// ^^^^^^^^^
        /// </summary>
        /// <param name="position">позиция определяется из номера четверти</param>
        /// <returns>часть матрицы, представляющая четверть</returns>
        public Matrix GetHalfMatrix(byte position)
        {
            int length = RowsCount / 2;

            switch (position)
            {
                case 0: return GetSubmatrix(0, length - 1, 0, length - 1);
                case 1: return GetSubmatrix(length, RowsCount - 1, 0, length - 1);
                case 2: return GetSubmatrix(0, length - 1, length, ColumnsCount - 1);
                case 3: return GetSubmatrix(length, RowsCount - 1, length, ColumnsCount - 1);
                default: throw new ArgumentException("can be only 0, 1, 2, or 3", "position");
            }
        }

        /// <summary>
        /// Передаёт размер матрицы в большую чётную сторону.
        /// </summary>
        /// <returns>лучший размер матрицы</returns>
        private int GetEvenLength()
        {
            var length = Math.Max(RowsCount, ColumnsCount);
            if (length % 2 == 1) length++;
            return length;
        }

        /// <summary>
        /// Передаёт часть матрицы в виде матрицы.
        /// </summary>
        /// <param name="iStart">первая строка для отбора</param>
        /// <param name="iEnd">последняя строка для отбора (включительно)</param>
        /// <param name="jStart">первый столбец для отбора</param>
        /// <param name="jEnd">последний столбец для отбора (включительно)</param>
        /// <returns>новая матрица, основанная частично на старой матрице</returns>
        private Matrix GetSubmatrix(int iStart, int iEnd, int jStart, int jEnd)
        {
            if (iStart < 0 ||
                jStart < 0 ||
                iEnd < 0 ||
                jEnd < 0 ||
                iStart > RowsCount - 1 ||
                jStart > ColumnsCount - 1 ||
                iEnd > RowsCount - 1 ||
                jEnd > ColumnsCount - 1
                )
                throw new ArgumentOutOfRangeException("indices are wrong");

            var tmpMatrix = new Matrix(iEnd - iStart + 1, jEnd - jStart + 1);
            // индексы для новой матрицы
            var indexI = 0;
            var indexJ = 0;

            for (var i = iStart; i <= iEnd; i++)
            {
                indexJ = 0;
                for (var j = jStart; j <= jEnd; j++)
                {
                    tmpMatrix[indexI, indexJ] = values[i, j];
                    indexJ++;
                }
                indexI++;
            }

            return tmpMatrix;
        }
    }
}

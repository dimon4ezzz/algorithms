using System;
using Recursio;

namespace Matrixing
{
    public class StrassenMultiply : IMultiply, IRecurced
    {
        public ulong CallsAmount { get; private set; }

        public StrassenMultiply() => ResetCounter();

        public void ResetCounter() =>
            CallsAmount = 0;

        public Matrix Multiply(Matrix left, Matrix right)
        {
            left.MakeSquareAndEven();
            right.MakeSquareAndEven();

            if (left.ColumnsCount != right.RowsCount)
                throw new ArgumentException("cannot multiply bad matrices");

            if (left.ColumnsCount < 48)
                return new DefaultMultiply().Multiply(left, right);

            CallsAmount++;

            var lq = new Matrix[4];
            var rq = new Matrix[4];

            // разделяем матрицы на четыре
            for (byte i = 0; i < 4; i++)
            {
                lq[i] = left.GetHalfMatrix(i);
                rq[i] = right.GetHalfMatrix(i);
            }

            var strassenArray = new Matrix[]
            {
                Multiply(lq[0] + lq[3], rq[0] + rq[3]),
                Multiply(lq[2] + lq[3], rq[0]),
                Multiply(lq[0], rq[1] - rq[3]),
                Multiply(lq[3], rq[2] - rq[0]),
                Multiply(lq[0] + lq[1], rq[3]),
                Multiply(lq[2] - lq[0], rq[0] + rq[1]),
                Multiply(lq[1] - lq[3], rq[2] + rq[3]),
                // Multiply(lq[0] - lq[2], rq[0] + rq[1]),
            };

            var strassenMatrices = new Matrix[]
            {
                strassenArray[0] + strassenArray[3] - strassenArray[4] + strassenArray[6],
                strassenArray[2] + strassenArray[4],
                strassenArray[1] + strassenArray[3],
                strassenArray[0] - strassenArray[1] + strassenArray[2] + strassenArray[5]
                // strassenArray[0] - strassenArray[1] + strassenArray[2] - strassenArray[5]
            };

            return CombineMatrices(strassenMatrices);
        }

        /// <summary>
        /// «Склеивает» матрицы слева направо, сверху вниз.
        /// </summary>
        /// <param name="matrices">матрицы</param>
        /// <returns>матрица</returns>
        private Matrix CombineMatrices(params Matrix[] matrices)
        {
            var amount = (int) Math.Sqrt(matrices.Length);
            var length = matrices[0].RowsCount;

            var tmpMatrix = new Matrix(length, length);

            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    tmpMatrix[i, j] = (matrices[0])[i, j];
                    tmpMatrix[i + length, j] = (matrices[1])[i, j];
                    tmpMatrix[i, j + length] = (matrices[2])[i, j];
                    tmpMatrix[i + length, j + length] = (matrices[3])[i, j];
                }
            }

            return tmpMatrix;
        }
    }
}

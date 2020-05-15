using System;

namespace Matrixing
{
    public class DefaultMultiply : IMultiply
    {
        public Matrix Multiply(Matrix left, Matrix right)
        {
            if (left.ColumnsCount != right.RowsCount)
                throw new ArgumentException("cannot multiply bad matrices");

            var tmpMatrix = new Matrix(left.RowsCount, right.ColumnsCount);

            for (var i = 0; i < left.RowsCount; i++)
                for (var j = 0; j < right.ColumnsCount; j++)
                    for (var k = 0; k < left.ColumnsCount; k++)
                        tmpMatrix[i, j] += left[i, k] * right[k, j];

            return tmpMatrix;
        }
    }
}

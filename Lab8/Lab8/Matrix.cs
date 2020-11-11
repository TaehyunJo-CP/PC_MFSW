using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab8
{
    public static class Matrix
    {
        public static int DotProduct(int[] v1, int[] v2)
        {
            int result = 0;
            for (int i = 0; i < v1.Length; i++)
            {
                result += v1[i] * v2[i];
            }
            return result;
        }

        public static int[,] Transpose(int[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            int[,] result = new int[colLength, rowLength];

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }
            return result;
        }

        public static int[,] GetIdentityMatrix(int size)
        {
            int[,] result = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                result[i, i] = 1;
            }

            return result;
        }

        public static int[] GetRowOrNull(int[,] matrix, int row)
        {
            if (matrix.GetLength(0) <= row)
            {
                return null;
            }

            int colLength = matrix.GetLength(1);

            int[] result = new int[colLength];

            for (int i = 0; i < colLength; i++)
            {
                result[i] = matrix[row, i];
            }

            return result;
        }

        public static int[] GetColumnOrNull(int[,] matrix, int col)
        {
            if (matrix.GetLength(1) <= col)
            {
                return null;
            }

            int rowLength = matrix.GetLength(0);

            int[] result = new int[rowLength];

            for (int i = 0; i < rowLength; i++)
            {
                result[i] = matrix[i, col];
            }

            return result;
        }

        public static int[] MultiplyMatrixVectorOrNull(int[,] matrix, int[] vector)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            int vectorLength = vector.Length;

            if (colLength != vectorLength)
            {
                return null;
            }

            int[] result = new int[rowLength];

            for (int i = 0; i < rowLength; i++)
            {
                int producted = 0;

                for (int j = 0; j < colLength; j++)
                {
                    producted += matrix[i, j] * vector[j];
                }

                result[i] = producted;
            }

            return result;
        }

        public static int[] MultiplyVectorMatrixOrNull(int[] vector, int[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            int vectorLength = vector.Length;

            if (rowLength != vectorLength)
            {
                return null;
            }

            int[] result = new int[colLength];

            for (int i = 0; i < colLength; i++)
            {
                int producted = 0;

                for (int j = 0; j < rowLength; j++)
                {
                    producted += matrix[j, i] * vector[j];
                }

                result[i] = producted;
            }

            return result;
        }

        public static int[,] MultiplyOrNull(int[,] multiplicandMatrix, int[,] multiplierMatrix)
        {
            int leftRowLength = multiplicandMatrix.GetLength(0);
            int leftColLength = multiplicandMatrix.GetLength(1);

            int rightRowLength = multiplierMatrix.GetLength(0);
            int rightColLength = multiplierMatrix.GetLength(1);

            if (leftColLength != rightRowLength)
            {
                return null;
            }

            int[,] result = new int[leftRowLength, rightColLength];

            for (int i = 0; i < leftRowLength; i++)
            {
                for (int j = 0; j < rightColLength; j++)
                {
                    result[i, j] = Matrix.DotProduct(Matrix.GetRowOrNull(multiplicandMatrix, i), Matrix.GetColumnOrNull(multiplierMatrix, j));
                }
            }
            return result;
        }




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int resultSum = int.MinValue;
            int resultRow = 0;
            int resultCol = 0;

            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var maxRows = input[0];
            var maxCols = input[1];

            int[][] matrix = new int[maxRows][];

            for (int row = 0; row < maxRows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < maxRows - 2; row++)
            {
                var currentSum = 0;

                for (int col = 0; col < maxCols - 2; col++)
                {
                    for (int innerRow = 0; innerRow < 3; innerRow++)
                    {
                        for (int innerCol = 0; innerCol < 3; innerCol++)
                        {
                            currentSum += matrix[row + innerRow][col + innerCol];
                        }
                    }

                    if (currentSum > resultSum)
                    {
                        resultSum = currentSum;
                        resultRow = row;
                        resultCol = col;
                    }
                    currentSum = 0;
                }
            }

            Console.WriteLine($"Sum = {resultSum}");
            for (int row = resultRow; row < resultRow + 3; row++)
            {
                for (int col = resultCol; col < resultCol + 3; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

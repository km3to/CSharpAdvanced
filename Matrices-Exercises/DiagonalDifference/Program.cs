using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxRows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[maxRows][];

            for (int row = 0; row < maxRows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var firstDiagonal = 0;
            var secondDiagonal = 0;

            for (int row = 0; row < maxRows; row++)
            {
                firstDiagonal += matrix[row][row];
            }

            for (int i = maxRows - 1; i >= 0; i--)
            {
                secondDiagonal += matrix[maxRows - 1 - i][i];
            }

            Console.WriteLine(Math.Abs(firstDiagonal - secondDiagonal));
        }
    }
}

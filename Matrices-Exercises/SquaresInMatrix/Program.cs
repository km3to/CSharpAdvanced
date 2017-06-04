using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfSquares = 0;
            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var maxRows = input[0];
            var maxCols = input[1];

            string[][] matrix = new string[maxRows][];

            //Fill matrix
            for (int row = 0; row < maxRows; row++)
            {
                matrix[row] = Console.ReadLine().Split(' ').ToArray();
            }

            for (int row = 0; row < maxRows - 1; row++)
            {
                for (int col = 0; col < maxCols - 1; col++)
                {
                    if (matrix[row][col] == matrix[row][col + 1] &&
                        matrix[row][col] == matrix[row + 1][col] &&
                        matrix[row][col] == matrix[row + 1][col + 1])
                    {
                        numberOfSquares++;
                    }
                }
            }

            Console.WriteLine(numberOfSquares);
        }
    }
}

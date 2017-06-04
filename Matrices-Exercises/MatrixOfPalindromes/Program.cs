using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var ch = 97;

            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int maxRows = input[0];
            int maxCols = input[1];

            string[][] matrix = new string[maxRows][];

            for (int row = 0; row < maxRows; row++)
            {
                matrix[row] = new string[maxCols];

                for (int col = 0; col < maxCols; col++)
                {
                    matrix[row][col] = char.ConvertFromUtf32(ch + row) + char.ConvertFromUtf32(ch + row + col) +
                                       char.ConvertFromUtf32(ch + row);
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}

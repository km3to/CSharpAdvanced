using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int[][] firstMatrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                firstMatrix[i] = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int[][] secondMatrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                secondMatrix[i] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                Array.Reverse(secondMatrix[i]);
            }

            bool matricesMatch = true;
            int sumMatricesLength = firstMatrix[0].Length + secondMatrix[0].Length;
            for (int i = 1; i < n; i++)
            {
                if (firstMatrix[i].Length + secondMatrix[i].Length != sumMatricesLength)
                {
                    matricesMatch = false;
                }
            }

            if (matricesMatch)
            {
                for (int i = 0; i < n; i++)
                {
                    int[] combined = firstMatrix[i].Concat(secondMatrix[i]).ToArray();
                    Console.WriteLine($"[{string.Join(", ", combined)}]");
                }
            }
            else
            {
                int totalCells = 0;
                for (int i = 0; i < n; i++)
                {
                    totalCells += firstMatrix[i].Length;
                    totalCells += secondMatrix[i].Length;
                }
                Console.WriteLine($"The total number of cells is: {totalCells}");
            }
        }

        public static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}

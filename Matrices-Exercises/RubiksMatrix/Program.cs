using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputDimensions = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var inputRows = inputDimensions[0];
            var inputCols = inputDimensions[1];

            int[][] originalMatrix = GenerateMatrix(inputRows, inputCols);

            var numberOfShuffles = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfShuffles; i++)
            {
                var inputLine = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var indexRowCol = int.Parse(inputLine[0]);
                var direction = inputLine[1];
                var moves = int.Parse(inputLine[2]);

                switch (direction)
                {
                    case "up":
                        UpDownShuffle(originalMatrix, indexRowCol, moves);
                        break;
                    case "down":
                        UpDownShuffle(originalMatrix, indexRowCol, inputRows - moves % inputRows);
                        break;
                    case "left":
                        LeftRightShuffle(originalMatrix, indexRowCol, moves);
                        break;
                    case "right":
                        LeftRightShuffle(originalMatrix, indexRowCol, inputCols - moves % inputCols);
                        break;
                }
            }

            var filler = 1;
            for (int rowIndex = 0; rowIndex < originalMatrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < originalMatrix[0].Length; colIndex++)
                {
                    if (originalMatrix[rowIndex][colIndex] == filler)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < originalMatrix.Length; r++)
                        {
                            for (int c = 0; c < originalMatrix[0].Length; c++)
                            {
                                if (originalMatrix[r][c] == filler)
                                {
                                    var currentFiller = originalMatrix[rowIndex][colIndex];
                                    originalMatrix[rowIndex][colIndex] = filler;
                                    originalMatrix[r][c] = currentFiller;
                                    Console.WriteLine($"Swap ({rowIndex}, {colIndex}) with ({r}, {c})");
                                    break;
                                }
                            }
                        }
                    }
                    filler++;
                }
            }
        }

        private static void LeftRightShuffle(int[][] matrix, int indexRowCol, int moves)
        {
            var tempArray = new int[matrix[0].Length];

            for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
            {
                tempArray[colIndex] = matrix[indexRowCol][(colIndex + moves) % matrix[0].Length];
            }

            matrix[indexRowCol] = tempArray;
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var line in matrix)
            {
                Console.WriteLine(string.Join(" ", line));
            }
        }
        
        private static void UpDownShuffle(int[][] matrix, int indexRowCol, int moves)
        {
            var tempArray = new int[matrix.Length];
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                tempArray[rowIndex] = matrix[(rowIndex + moves) % matrix.Length][indexRowCol];
            }

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex][indexRowCol] = tempArray[rowIndex];
            }
        }

        private static int[][] GenerateMatrix(int inputRows, int inputCols)
        {
            int[][] matrix = new int[inputRows][];
            var filler = 1;

            for (int row = 0; row < inputRows; row++)
            {
                matrix[row] = new int[inputCols];
                for (int col = 0; col < inputCols; col++)
                {
                    matrix[row][col] = filler++;
                }
            }

            return matrix;
        }
    }
}

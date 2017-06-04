using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioactiveBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int resultRow = 0;
            int resultCol = 0;

            var dimensions = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            char[][] matrix = new char[rows][];
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine().ToCharArray();
            }

            var commands = Console.ReadLine().ToCharArray();

            // Find Player Position
            int playerRow = 0;
            int playerCol = 0;
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == 'P')
                    {
                        playerRow = rowIndex;
                        playerCol = colIndex;
                    }
                }
            }
            matrix[playerRow][playerCol] = '.';

            // Start Of Move
            for (int move = 0; move < commands.Length; move++)
            {
                Queue<int> bunniesRows = new Queue<int>();
                Queue<int> bunniesCols = new Queue<int>();

                // Collect co-ordinates with 'B'
                for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                    {
                        if (matrix[rowIndex][colIndex] == 'B')
                        {
                            bunniesRows.Enqueue(rowIndex);
                            bunniesCols.Enqueue(colIndex);
                        }
                    }
                }

                // Multiply 'B's
                while (bunniesRows.Count > 0)
                {
                    var rowIndex = bunniesRows.Dequeue();
                    var colIndex = bunniesCols.Dequeue();
                    if (IsInsideMatrix(matrix, rowIndex - 1, colIndex))
                    {
                        matrix[rowIndex - 1][colIndex] = 'B';
                    }
                    if (IsInsideMatrix(matrix, rowIndex + 1, colIndex))
                    {
                        matrix[rowIndex + 1][colIndex] = 'B';
                    }
                    if (IsInsideMatrix(matrix, rowIndex, colIndex - 1))
                    {
                        matrix[rowIndex][colIndex - 1] = 'B';
                    }
                    if (IsInsideMatrix(matrix, rowIndex, colIndex + 1))
                    {
                        matrix[rowIndex][colIndex + 1] = 'B';
                    }
                }
                
                // Moves Player
                switch (commands[move])
                {
                    case 'U':
                        if (!IsInsideMatrix(matrix, playerRow - 1, playerCol))
                        {
                            PrintMatrix(matrix);
                            Console.WriteLine($"won: {playerRow} {playerCol}");
                            return;
                        }
                        else if (matrix[playerRow - 1][playerCol] == 'B')
                        {
                            PrintMatrix(matrix);
                            Console.WriteLine($"dead: {playerRow - 1} {playerCol}");
                            return;
                        }
                        else
                        {
                            playerRow--;
                        }
                        break;
                    case 'D':
                        if (!IsInsideMatrix(matrix, playerRow + 1, playerCol))
                        {
                            PrintMatrix(matrix);
                            Console.WriteLine($"won: {playerRow} {playerCol}");
                            return;
                        }
                        else if (matrix[playerRow + 1][playerCol] == 'B')
                        {
                            PrintMatrix(matrix);
                            Console.WriteLine($"dead: {playerRow + 1} {playerCol}");
                            return;
                        }
                        else
                        {
                            playerRow++;
                        }
                        break;
                    case 'L':
                        if (!IsInsideMatrix(matrix, playerRow, playerCol - 1))
                        {
                            PrintMatrix(matrix);
                            Console.WriteLine($"won: {playerRow} {playerCol}");
                            return;
                        }
                        else if (matrix[playerRow][playerCol - 1] == 'B')
                        {
                            PrintMatrix(matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol - 1}");
                            return;
                        }
                        else
                        {
                            playerCol--;
                        }
                        break;
                    case 'R':
                        if (!IsInsideMatrix(matrix, playerRow, playerCol + 1))
                        {
                            PrintMatrix(matrix);
                            Console.WriteLine($"won: {playerRow} {playerCol}");
                            return;
                        }
                        else if (matrix[playerRow][playerCol + 1] == 'B')
                        {
                            PrintMatrix(matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol + 1}");
                            return;
                        }
                        else
                        {
                            playerCol++;
                        }
                        break;
                }
            }
        }

        public static bool IsInsideMatrix(char[][] matrix, int row, int col)
        {
            if (row < 0 || row >= matrix.Length)
            {
                return false;
            }
            if (col < 0 || col >= matrix[row].Length)
            {
                return false;
            }
            return true;
        }

        public static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMatrixRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var firstIndex = input.IndexOf('(');
            var secondIndex = input.IndexOf(')');
            int degrees = int.Parse(input.Substring(firstIndex + 1, secondIndex - firstIndex - 1));
            Queue<string> words = new Queue<string>();
            HashSet<int> lenghts = new HashSet<int>();

            var inputLine = Console.ReadLine();
            while (inputLine != "END")
            {
                words.Enqueue(inputLine);
                lenghts.Add(inputLine.Length);
                inputLine = Console.ReadLine();
            }

            int maxLenght = lenghts.Max();
            ResizeQueueTokens(words, maxLenght);

            int numberOfRoratations = (degrees / 90) % 4;
            switch (numberOfRoratations)
            {
                case 0:
                    CreateMatrixFromStringArr(words.ToArray());
                    break;
                case 1:
                    Rotate90(words.ToArray(), maxLenght);
                    break;
                case 2:
                    Rotate180(words.ToArray(), maxLenght);
                    break;
                case 3:
                    Rotate270(words.ToArray(), maxLenght);
                    break;
            }
        }

        private static void CreateMatrixFromStringArr(string[] words)
        {
            char[][] matrix = new char[words.Length][];
            for (int i = 0; i < words.Length; i++)
            {
                matrix[i] = words[i].ToCharArray();
            }

            PrintMatrix(matrix);
        }

        private static void Rotate180(string[] words, int maxLenght)
        {
            char[][] matrix = new char[words.Length][];
            for (int i = words.Length - 1, j = 0; i >= 0; i--, j++)
            {
                matrix[j] = words[i].Reverse().ToArray();
            }

            PrintMatrix(matrix);
        }

        private static void Rotate270(string[] words, int maxLenght)
        {
            char[][] matrix = new char[maxLenght][];

            for (int rowIndex = 0; rowIndex < maxLenght; rowIndex++)
            {
                matrix[rowIndex] = new char[words.Length];
                for (int colIndex = 0; colIndex < words.Length; colIndex++)
                {
                    matrix[rowIndex][colIndex] = words[colIndex][maxLenght - 1 - rowIndex];
                }
            }

            PrintMatrix(matrix);
        }

        private static void Rotate90(string[] words, int maxLenght)
        {
            char[][] matrix = new char[maxLenght][];

            for (int rowIndex = 0; rowIndex < maxLenght; rowIndex++)
            {
                matrix[rowIndex] = new char[words.Length];
                for (int colIndex = 0; colIndex < words.Length; colIndex++)
                {
                    matrix[rowIndex][colIndex] = words[words.Length - 1 - colIndex][rowIndex];
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void ResizeQueueTokens(Queue<string> words, int maxLenght)
        {
            int queueLen = words.Count;
            for (int i = 0; i < queueLen; i++)
            {
                string tmpWord = words.Dequeue();
                int tmpLen = tmpWord.Length;
                if (tmpLen < maxLenght)
                {
                    tmpWord = tmpWord + new String(' ', maxLenght - tmpLen);
                }
                words.Enqueue(tmpWord);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGraduation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numberOfStudents = int.Parse(Console.ReadLine());
            var students = new SortedDictionary<string, List<double>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                var name = Console.ReadLine();
                var scores = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
                    .ToList();

                students.Add(name, scores);
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Average()}");
            }
        }
    }
}

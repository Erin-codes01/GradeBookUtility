using System;
using System.Collections.Generic;
using System.Linq;

namespace GradebookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Gradebook Application!");
            var gradebook = new Gradebook();

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Grade");
                Console.WriteLine("2. View Statistics");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Enter grade: ");
                        if (double.TryParse(Console.ReadLine(), out double grade))
                        {
                            gradebook.AddGrade(grade);
                            Console.WriteLine("Grade added.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid grade input.");
                        }
                        break;

                    case "2":
                        Console.WriteLine($"Average: {gradebook.GetAverage():F2}");
                        var (highest, lowest) = gradebook.GetHighestAndLowest();
                        Console.WriteLine($"Highest: {highest}");
                        Console.WriteLine($"Lowest: {lowest}");
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }

    // 👇 Replaces your old Gradebook class so it matches your tests
    public class Gradebook
    {
        private readonly List<double> _grades = new();

        public void AddGrade(double grade)
        {
            _grades.Add(grade);
        }

        public IReadOnlyList<double> GetGrades()
        {
            return _grades;
        }

        public double GetAverage()
        {
            return _grades.Any() ? _grades.Average() : 0;
        }

        public (double highest, double lowest) GetHighestAndLowest()
        {
            if (!_grades.Any())
                return (0, 0);

            return (_grades.Max(), _grades.Min());
        }
    }
}

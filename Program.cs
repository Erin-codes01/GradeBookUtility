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
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Grade");
                Console.WriteLine("3. View Grades");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Write("Enter student name: ");
                        var name = Console.ReadLine();
                        gradebook.AddStudent(name);
                        break;
                    case "2":
                        Console.Write("Enter student name: ");
                        var studentName = Console.ReadLine();
                        Console.Write("Enter grade: ");
                        if (double.TryParse(Console.ReadLine(), out double grade))
                        {
                            gradebook.AddGrade(studentName, grade);
                        }
                        else
                        {
                            Console.WriteLine("Invalid grade input.");
                        }
                        break;
                    case "3":
                        gradebook.DisplayGrades();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
    class Gradebook
    {
        private Dictionary<string, List<double>> _grades = new Dictionary<string, List<double>>();
        public void AddStudent(string name)
        {
            if (!_grades.ContainsKey(name))
            {
                _grades[name] = new List<double>();
                Console.WriteLine($"Student '{name}' added.");
            }
            else
            {
                Console.WriteLine($"Student '{name}' already exists.");
            }
        }
        public void AddGrade(string studentName, double grade)
        {
            if (_grades.ContainsKey(studentName))
            {
                _grades[studentName].Add(grade);
                Console.WriteLine($"Grade {grade} added for student '{studentName}'.");
            }
            else
            {
                Console.WriteLine($"Student '{studentName}' not found.");
            }
        }
        public void DisplayGrades()
        {
            foreach (var student in _grades)
            {
                var average = student.Value.Any() ? student.Value.Average() : 0;
                Console.WriteLine($"{student.Key}: Average Grade = {average:F2}");
            }
        }

    }

}
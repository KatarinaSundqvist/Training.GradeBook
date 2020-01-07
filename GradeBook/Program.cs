using System;
using System.Collections.Generic;

namespace GradeBook {
    class Program {
        static void Main(string[] args) {
            IBook book = new DiskBook("Scott's Grade Book");
            book.GradeAdded += OnGradeAdded;

            Console.WriteLine("Please enter a grade. Type q to stop:");
            EnterGrades(book);

            var stats = book.GetStats();
            Console.WriteLine($"For the book named {book.Name}:");
            Console.WriteLine($"The average of the grades is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }

        private static void EnterGrades(IBook book) {
            while (true) {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q") {
                    break;
                }
                try {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex) {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e) {
            Console.WriteLine("A grade was added");
        }
    }
}

using System;
using System.Collections.Generic;

namespace GradeBook {
    class Program {
        static void Main(string[] args) {

            var book = new Book("Scott's Grade Book");
            book.GradeAdded += OnGradeAdded;

            Console.WriteLine("Please enter a grade. Type q to stop:");
            var input = Console.ReadLine();
            double parsedInput;

            while (input != "q") {
                while (!double.TryParse(input, out parsedInput)) {
                    Console.WriteLine("Not a number, please try again");
                    input = Console.ReadLine();
                }

                try {
                    book.AddGrade(parsedInput);
                }
                catch(ArgumentException ex) {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex) {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Please enter the next grade. Type q to stop:");
                input = Console.ReadLine();
            }

            var stats = book.GetStats();
            Console.WriteLine($"For the book named {book.Name}:");
            Console.WriteLine($"The average of the grades is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }

        static void OnGradeAdded(object sender, EventArgs e) {
            Console.WriteLine("A grade was added");
        }
    }
}

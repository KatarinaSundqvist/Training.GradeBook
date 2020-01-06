using System;
using System.Collections.Generic;

namespace GradeBook {
    class Program {
        static void Main(string[] args) {

            var book = new Book("Scott's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            var stats = book.GetStats();
            Console.WriteLine($"The average of the grades is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }
    }
}

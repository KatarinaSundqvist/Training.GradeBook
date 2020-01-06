using System;
using System.Collections.Generic;

namespace GradeBook {
    public class Book {

        public Book(string name) {
            grades = new List<double>();
            Name = name;
        }

        public void AddLetterGrade(char letter) {
            switch (letter) {
                case 'A':
                    AddGrade(100);
                    break;
                case 'B':
                    AddGrade(89);
                    break;
                case 'C':
                    AddGrade(79);
                    break;
                case 'D':
                    AddGrade(69);
                    break;
                case 'F':
                    AddGrade(59);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade) {
            if (grade <= 100 && grade >= 0) {
                grades.Add(grade);
            }
            else {
                Console.WriteLine("Invalid value");
            }
        }

        public List<double> GetGrades() {
            return grades;
        }

        public Stats GetStats() {
            var result = new Stats();
            var gradeTotal = 0.0;
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            for (var i = 0; i < grades.Count; i++) {
                result.High = Math.Max(grades[i], result.High);
                result.Low = Math.Min(grades[i], result.Low);
                gradeTotal += grades[i];
            }

            result.Average = gradeTotal / grades.Count;

            switch (result.Average) {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        private List<double> grades;

        public string Name;
    }
}
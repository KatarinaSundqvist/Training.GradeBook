using System;
using System.Collections.Generic;

namespace GradeBook {

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class InMemoryBook : Book {

        public InMemoryBook(string name) : base(name) {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter) {
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

        public override void AddGrade(double grade) {
            if (grade <= 100 && grade >= 0) {
                grades.Add(grade);
                GradeAdded?.Invoke(this, new EventArgs());
            }
            else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Stats GetStats() {
            var result = new Stats();
            for (var i = 0; i < grades.Count; i++) {
                result.Add(grades[i]);
            }
            return result;
        }

        private List<double> grades;

        public const string CATEGORY = "Science";
    }
}
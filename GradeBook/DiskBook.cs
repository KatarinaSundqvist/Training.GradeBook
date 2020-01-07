using System.Collections.Generic;
using System.IO;

namespace GradeBook {
    public class DiskBook : Book {

        public DiskBook(string name) : base(name) {
            //grades = new List<double>();
            //Name = name;
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade) {
            using (var writer = File.AppendText($"{TEMPFOLDER}{Name}.txt")) {
                writer.WriteLine(grade);
                GradeAdded?.Invoke(this, new System.EventArgs());
            }
        }

        public override Stats GetStats() {
            var result = new Stats();
            using (var reader = File.OpenText($"{TEMPFOLDER}{Name}.txt")) {
                var line = reader.ReadLine();
                while (line != null) {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }

        //private List<double> grades;

        public const string TEMPFOLDER = "C:\\Temp\\";
    }
}
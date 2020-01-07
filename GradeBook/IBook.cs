using GradeBook;

public interface IBook {
    void AddGrade(double grade);
    Stats GetStats();
    string Name { get; }
    event GradeAddedDelegate GradeAdded;
}
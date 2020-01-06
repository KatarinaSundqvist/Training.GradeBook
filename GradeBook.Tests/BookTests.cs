using System;
using System.Collections.Generic;
using Xunit;

namespace GradeBook.Tests {
    public class BookTests {
        [Fact]
        public void BookCalculatesAnAverageGrade() {
            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            book.GetStats();
            var result = book.GetStats();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);

        }

        [Fact]
        public void AddGradeOnlyAddsValidValues() {
            var book = new Book("Test");
            book.AddGrade(105);
            book.AddGrade(-5);
            var result = book.GetGrades();

            Assert.Empty(result);
        }
    }
}

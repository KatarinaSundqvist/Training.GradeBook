using System;
using Xunit;

namespace GradeBook.Tests {

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests {

        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod() {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;
            var result = log("Hello!");

            Assert.Equal(3, count);
        }

        string IncrementCount(string message) {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message) {
            count++;
            return message;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes() {
            string name = "Scott";
            var upper = MakeUppercase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUppercase(string parameter) {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesCanAlsoPassByRef() {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z) {
            z = 42;
        }


        [Fact]
        public void ValueTypesAlsoPassByValue() {
            var x = GetInt();
            SetInt(x);

            Assert.Equal(3, x);
        }

        private void SetInt(int x) {
            x = 42;
        }

        private int GetInt() {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByReferenceUsingOut() {
            var book1 = GetBook("Book 1");
            GetBookSetNameOut(out book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameOut(out InMemoryBook book, string name) {
            book = new InMemoryBook(name); // Must initialise when using out
        }


        [Fact]
        public void CSharpCanPassByReference() {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name) {
            book = new InMemoryBook(name);
        }


        [Fact]
        public void CSharpIsPassByValue() {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name) {
            book = new InMemoryBook(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference() {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name) {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects() {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject() {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name) {
            return new InMemoryBook(name);
        }
    }
}

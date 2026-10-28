using Microsoft.VisualStudio.TestTools.UnitTesting;
using CB015673___SD_Assignment_1; // replace with your actual project namespace
using System;

namespace CB015673_SD_Assignment1_Tests
{
    [TestClass]
    public class BookTests
    {
        private Book testBook;

        [TestInitialize]
        public void Setup()
        {
            // Arrange - Create a test book before each test
            testBook = new Book
            {
                itemId = "0001",
                title = "To Kill a Mockingbird",
                isbn = "101",
                author = "Harper Lee",
                publishedYear = 1960,
                pageCount = 281,
                isAvailable = true
            };
        }

        [TestMethod]
        public void Book_Constructor_ShouldCreateValidBook()
        {
            Assert.AreEqual("0001", testBook.itemId);
            Assert.AreEqual("To Kill a Mockingbird", testBook.title);
            Assert.AreEqual("101", testBook.isbn);
            Assert.AreEqual("Harper Lee", testBook.author);
            Assert.AreEqual(1960, testBook.publishedYear);
            Assert.AreEqual(281, testBook.pageCount);
            Assert.IsTrue(testBook.isAvailable);
        }

        [TestMethod]
        public void Book_DisplayInfo_ShouldNotThrowException()
        {
            testBook.DisplayInfo();
        }

        [TestMethod]
        public void Book_IsAvailable_ShouldToggleCorrectly()
        {
            testBook.isAvailable = true;
            testBook.isAvailable = false;
            Assert.IsFalse(testBook.isAvailable);
        }

        [TestMethod]
        public void Book_PageCount_ShouldAcceptPositiveValues()
        {
            testBook.pageCount = 500;
            Assert.AreEqual(500, testBook.pageCount);
        }

        [TestMethod]
        public void Book_Properties_ShouldAcceptValidValues()
        {
            testBook.title = "New Title";
            testBook.author = "New Author";
            testBook.publishedYear = 2023;

            Assert.AreEqual("New Title", testBook.title);
            Assert.AreEqual("New Author", testBook.author);
            Assert.AreEqual(2023, testBook.publishedYear);
        }
    }
}

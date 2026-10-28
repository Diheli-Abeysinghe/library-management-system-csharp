using CB015673___SD_Assignment_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CB015673_SD_Assignment1_Tests
{
    [TestClass]
    public class ReferenceBookTests
    {
        private ReferenceBook testReferenceBook;

        [TestInitialize]
        public void Setup()
        {
            testReferenceBook = new ReferenceBook
            {
                itemId = "0002",
                title = "Oxford English Dictionary",
                isbn = "978-0198611868",
                isRestricted = true
            };
        }

        [TestMethod]
        public void ReferenceBook_Constructor_ShouldCreateValidReferenceBook()
        {
            Assert.AreEqual("0002", testReferenceBook.itemId);
            Assert.AreEqual("Oxford English Dictionary", testReferenceBook.title);
            Assert.AreEqual("978-0198611868", testReferenceBook.isbn);
            Assert.IsTrue(testReferenceBook.isRestricted);
        }

        [TestMethod]
        public void ReferenceBook_DisplayInfo_ShouldNotThrowException()
        {
            // Just call the method — test fails automatically if it throws
            testReferenceBook.DisplayInfo();
        }

        [TestMethod]
        public void ReferenceBook_IsRestricted_ShouldDefaultToTrue()
        {
            var newRefBook = new ReferenceBook();
            Assert.IsTrue(newRefBook.isRestricted);
        }

        [TestMethod]
        public void ReferenceBook_InheritsFromLibraryItem()
        {
            Assert.IsInstanceOfType(testReferenceBook, typeof(LibraryItem));
        }

        [TestMethod]
        public void ReferenceBook_CheckAvailability_ShouldInheritMethod()
        {
            testReferenceBook.CheckAvailability();
        }
    }
}

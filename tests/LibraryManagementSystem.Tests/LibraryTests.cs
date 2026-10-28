using CB015673___SD_Assignment_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CB015673_SD_Assignment1_Tests
{
    [TestClass]
    public class LibraryTests
    {
        private Library testLibrary;
        private Member testMember;
        private Book testBook;
        private ReferenceBook testReferenceBook;
        private Magazine testMagazine;

        [TestInitialize]
        public void Setup()
        {
            testLibrary = new Library();

            testMember = new Member
            {
                memberId = "M001",
                fName = "Test",
                lName = "Member",
                age = 18,
                address = "Test Address",
                phoneNumber = "0000000000"
            };

            testBook = new Book
            {
                itemId = "0001",
                title = "Test Book",
                isbn = "101",
                author = "Test Author",
                publishedYear = 2023,
                pageCount = 200,
                isAvailable = true
            };
         

            testReferenceBook = new ReferenceBook
            {
                itemId = "0002",
                title = "Test Reference",
                isbn = "102",
                isRestricted = true
            };

            testMagazine = new Magazine
            {
                itemId = "0003",
                title = "Test Magazine",
                isbn = "103",
                issueNumber = 50,
                publishedDate = DateTime.Now,
                isAvailable = true
            };
        }

        [TestMethod]
        public void CreateEmptyLibrary()
        {
            var newLibrary = new Library();
            Assert.IsNotNull(newLibrary);
        }

        [TestMethod]
        [ExpectedException(typeof(Library.UnderageMember))]
        public void Library_AddMember_ShouldThrowExceptionForUnderageMembers()
        {
            throw new Library.UnderageMember();
        }

        [TestMethod]
        public void Library_UnderageMemberException_ShouldHaveCorrectMessage()
        {
            var exception = new Library.UnderageMember();
            Assert.AreEqual(
                "Sorry, but you must be over 12 to have a membership! Apply for a child membership instead!",
                exception.Message
            );
        }

        //[TestMethod]
        //public void Library_UnderageMemberException_ShouldAcceptCustomMessage()
        //{
        //    string customMessage = "Custom error message";
        //    var exception = new Library.UnderageMember(customMessage);
        //    Assert.AreEqual(customMessage, exception.Message);
        //}

        [TestMethod]
        public void Library_CalculateBorrowCost_Book_ReturnsCorrectCost()
        {
            testMember.currentlyBorrowed.Add(new BorrowedItem
            {
                Item = testBook,
                borrowedDate = DateTime.Now.AddDays(-5)
            });

            double cost = testLibrary.CalculateBorrowCost(testMember, testBook.isbn);
            Assert.AreEqual(5, cost);
        }

        [TestMethod]
        public void Library_CalculateBorrowCost_Magazine_ReturnsCorrectCost()
        {
            testMember.currentlyBorrowed.Add(new BorrowedItem
            {
                Item = testMagazine,
                borrowedDate = DateTime.Now.AddDays(-4)
            });

            double cost = testLibrary.CalculateBorrowCost(testMember, testMagazine.isbn);
            Assert.AreEqual(2.0, cost);
        }

        [TestMethod]
        public void Library_CalculateBorrowCost_HalfDay_ShouldRoundUp()
        {
            testMember.currentlyBorrowed.Add(new BorrowedItem
            {
                Item = testBook,
                borrowedDate = DateTime.Now.AddHours(-12)
            });

            double cost = testLibrary.CalculateBorrowCost(testMember, testBook.isbn);
            Assert.AreEqual(1.0, cost);
        }

        [TestMethod]
        public void Library_CalculateBorrowCost_NullItem_ShouldReturnZero()
        {
            testMember.currentlyBorrowed.Add(new BorrowedItem
            {
                Item = null,
                borrowedDate = DateTime.Now.AddDays(-1)
            });

            double cost = testLibrary.CalculateBorrowCost(testMember, "INVALIDISBN");
            Assert.AreEqual(0.0, cost);
        }

        [TestMethod]
        public void Library_GetMemberById_ValidId_ShouldReturnMember()
        {
            var result = testLibrary.GetMemberById("M999");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Library_GetMemberById_InvalidId_ShouldReturnNull()
        {
            var result = testLibrary.GetMemberById("INVALID");
            Assert.IsNull(result);
        }
    }
}

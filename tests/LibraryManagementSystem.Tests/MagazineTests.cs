using CB015673___SD_Assignment_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CB015673_SD_Assignment1_Tests
{
    
        [TestClass]
        public class MagazineTests
        {
            private Magazine testMagazine;

            [TestInitialize]
            public void Setup()
            {
                testMagazine = new Magazine
                {
                    itemId = "0003",
                    title = "National Geographic",
                    isbn = "978-1234567890",
                    issueNumber = 150,
                    publishedDate = new DateTime(2023, 6, 15),
                    isAvailable = true
                };
            }

            [TestMethod]
            public void Magazine_Constructor_ShouldCreateValidMagazine()
            {
                Assert.AreEqual("0003", testMagazine.itemId);
                Assert.AreEqual("National Geographic", testMagazine.title);
                Assert.AreEqual("978-1234567890", testMagazine.isbn);
                Assert.AreEqual(150, testMagazine.issueNumber);
                Assert.AreEqual(new DateTime(2023, 6, 15), testMagazine.publishedDate);
                Assert.IsTrue(testMagazine.isAvailable);
            }

            [TestMethod]
            public void Magazine_DisplayInfo_ShouldNotThrowException()
            {
                testMagazine.DisplayInfo(); // will fail test automatically if exception is thrown
            }

            [TestMethod]
            public void Magazine_IssueNumber_ShouldAcceptPositiveValues()
            {
                testMagazine.issueNumber = 200;
                Assert.AreEqual(200, testMagazine.issueNumber);
            }

            [TestMethod]
            public void Magazine_PublishedDate_ShouldAcceptValidDates()
            {
                var newDate = new DateTime(2024, 12, 25);
                testMagazine.publishedDate = newDate;
                Assert.AreEqual(newDate, testMagazine.publishedDate);
            }

            [TestMethod]
            public void Magazine_InheritsFromLibraryItem()
            {
                Assert.IsInstanceOfType(testMagazine, typeof(LibraryItem));
            }
        }

    }

